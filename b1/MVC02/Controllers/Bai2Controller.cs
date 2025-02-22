using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC02.Models;

namespace MVC02.Controllers;

public class Bai2Controller : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Reverse(string input)
    {
        if(string.IsNullOrEmpty(input)){
            ViewData["chuỗi"] = "rỗng";
        } else {
            char[] output = input.ToCharArray();
            Array.Reverse(output);
            ViewData["chuỗi"] = new string(output);
        }
        
        return View();
    }

    public IActionResult Length(String input)
    {
        if(string.IsNullOrEmpty(input)){
            ViewData["độ dài"]  = "0";
        } else {
            ViewData["độ dài"] = $"Độ dài chuỗi là: {input.Length}";
        }
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
