using System.Diagnostics;
using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;
using MVC02.Models;

namespace MVC02.Controllers;

public class Bai2Controller : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Receive (string username, string password, string email){
        if (string.IsNullOrWhiteSpace(username))
        {
            ViewData["thông báo"] = "Username không được rỗng.";
            return View();
        } else if (password.Length < 8 || !password.Any(char.IsDigit))
        {
            ViewData["thông báo"] = "Password phải có ít nhất 8 ký tự và chứa ít nhất một số.";
            return View();
        } else if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            ViewData["thông báo"] = "Email không đúng định dạng.";
            return View();
        } else {
            ViewData["thông báo"] = $"Xin chào {username}, Bạn đã đăng kí thành công";
            return View();
        }        
    }

    [HttpGet]
    public IActionResult GetRandomNumbers(){
        return View();
    }

    [HttpPost]
    public IActionResult GetRandomNumbers(byte lb, byte ub, byte n){
        // byte? lb1 = lb;
        // byte? ub1 = ub;
        // byte? n1 = n;
        // if (lb1 == null || ub1 == null || n1 == null)
        // {
        //     return View();
        // }
        
        if (lb > ub)
        {
            ViewData["thông báo"] = "Giá trị lb phải nhỏ hơn ub.";
            return View("ShowRandomNumber", null);
        } else if (n == 0)
        {
            ViewData["thông báo"] = "Số lượng n phải lớn hơn 0.";
            return View("ShowRandomNumber", null);
        } else {
            var randomNumbers = new List<int>();
            var random = new Random();

            for (int i = 0; i < n; i++)
            {
                int number = random.Next(lb, ub + 1); 
                randomNumbers.Add(number);
            }

            ViewData["thông báo"] = null;
            ViewData["randomNumbers"] = randomNumbers;
        return View("ShowRandomNumber");
        }
    }

    public IActionResult Register (){
        return View();
    }

    public IActionResult ShowRandomNumber (){
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
