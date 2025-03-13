using System.Diagnostics;
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
        return View();
    }

    [HttpPost]
    public IActionResult Login(string Username, string Password)
    {
        // Kiểm tra thông tin đăng nhập từ database
        var member = _context.tblMembers.SingleOrDefault(m => m.MemberName == Username && m.Matkhau == Password);

        if (member != null)
        {
            // Tạo session
            HttpContext.Session.SetString("Username", member.MemberName);
            return RedirectToAction("Index", "Home"); // Chuyển hướng sau khi đăng nhập thành công
        }
        else
        {
            ViewBag.Error = "Tên đăng nhập hoặc mật khẩu không đúng.";
            return View();
        }
    }

    public IActionResult Logout()
    {
        // Xóa session khi đăng xuất
        HttpContext.Session.Remove("Username");
        return RedirectToAction("Login");
    }
}
