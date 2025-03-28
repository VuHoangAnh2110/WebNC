using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using MVC04.Data;
using MVC04.Models;

namespace BTL_NMCNPM.Controllers;

public class AccountController : Controller
{
    private readonly AppDbContext _context;

    private readonly IMemberRepository _MemberRepository;

    // Gộp cả hai dependency vào một constructor
    public AccountController(AppDbContext context, IMemberRepository MemberRepository)
    {
        _context = context;
        _MemberRepository = MemberRepository;
    }

    public IActionResult Login()
    {
        ViewBag.Locked = HttpContext.Session.GetString("Locked") == "true";
        ViewBag.Error = HttpContext.Session.GetString("LockoutMessage");

        return View();
    }

    [HttpPost]
    public IActionResult Login(string ipemail, string Password)
    {
        ViewBag.Locked = HttpContext.Session.GetString("Locked") == "true";
        ViewBag.Error = HttpContext.Session.GetString("LockoutMessage");

        // Xác định khóa session chung cho số lần nhập sai và thời gian khóa
        string failedLoginKey = "FailedLoginCount";
        string lockoutKey = "LockoutTime";

        // Lấy số lần nhập sai từ session
        int failedAttempts = HttpContext.Session.GetInt32(failedLoginKey) ?? 0;

        DateTime? lockoutEndTime = HttpContext.Session.GetString(lockoutKey) != null
            ? DateTime.Parse(HttpContext.Session.GetString(lockoutKey)) : (DateTime?)null;
        // Nếu tài khoản bị khóa, không cho đăng nhập
        if (lockoutEndTime != null && DateTime.UtcNow < lockoutEndTime)
        {
            HttpContext.Session.SetString("Locked", "true"); // Lưu trạng thái khóa vào session
            HttpContext.Session.SetString("LockoutMessage", $"Tài khoản đã bị khóa. Vui lòng thử lại sau {lockoutEndTime.Value.Subtract(DateTime.UtcNow).Minutes} phút.");
            return View();
        }

        // Mã hóa mật khẩu trước khi kiểm tra
        string hashedPassword = HashPassword(Password);
        // Sử dụng repository để tìm kiếm tài khoản
        var member = _MemberRepository.GetByEmail(ipemail);
        // Kiểm tra nếu tài khoản tồn tại và mật khẩu khớp
        if (member != null && member.PasswordHash == hashedPassword)
        {
            // Đăng nhập thành công => Xóa thông tin khóa tài khoản
            HttpContext.Session.Remove(failedLoginKey);
            HttpContext.Session.Remove(lockoutKey);
            HttpContext.Session.Remove("Locked");
            HttpContext.Session.Remove("LockoutMessage");

            // Lưu session đăng nhập
            HttpContext.Session.SetString("Username", member.MemberID);
            return RedirectToAction("Index", "Home"); // Điều hướng sau khi đăng nhập
        }
        else
        {
            // Nếu sai thông tin, tăng số lần nhập sai
            failedAttempts++;
            HttpContext.Session.SetInt32(failedLoginKey, failedAttempts);

            if (failedAttempts >= 2)
            {
                // Nếu nhập sai >= 3 lần, khóa tài khoản trong 30 phút
                DateTime lockoutUntil = DateTime.UtcNow.AddMinutes(30);
                HttpContext.Session.SetString(lockoutKey, lockoutUntil.ToString());
                HttpContext.Session.SetString("Locked", "true");
                HttpContext.Session.SetString("LockoutMessage", "Bạn đã nhập sai 3 lần. Tài khoản bị khóa trong 30 phút.");            }
            else
            {
                ViewBag.Error = $"Tên đăng nhập hoặc mật khẩu không đúng. Bạn còn {3 - failedAttempts} lần thử.";
            }

            return View();
        }
    }

    public IActionResult Logout()
    {
        // Xóa session khi đăng xuất
        HttpContext.Session.Remove("Username");
        return RedirectToAction("Login");
    }

    public IActionResult ThongBao(){
        return View();
    }

    public IActionResult DangKy(){
        return View();
    }

    [HttpPost]
    public IActionResult DangKy (DangKyViewModel model){
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        // Kiểm tra Email đã tồn tại
        if (_MemberRepository.IsEmailExists(model.Email))
        {
            ModelState.AddModelError("Email", "Email đã tồn tại, thử lại.");
            return View(model);
        }

        // Mã hóa mật khẩu
        string hashedPassword = HashPassword(model.Password);

        // Tạo thành viên mới
        var newMember = new Member
        {
            MemberID = Convert.ToBase64String(Guid.NewGuid().ToByteArray()).TrimEnd('='),
            Fullname = model.Fullname,
            Email = model.Email,
            PasswordHash = hashedPassword,
            CreateAt = DateTime.UtcNow
        };

        // Lưu vào DB qua repository
        _MemberRepository.AddMember(newMember);

        TempData["Success"] = "Đăng ký thành công!";
        return RedirectToAction("ThongBao");
    }

    // Mã hóa 
    private string HashPassword(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }
    }

}
