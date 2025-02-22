using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC03.Models;

namespace MVC03.Controllers;

public class Bai3Controller : Controller
{
  
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Add(int a, int b)
    {
        if(a == null || b == null){
            ViewData["tổng"] = "Vui lòng nhập 2 số";
        } else {
            ViewData["tổng"] = $"Tổng của {a} và {b} là: {a + b}";
        }
        return View();
    }

    public IActionResult Multiply(int a, int b)
    {
        if(a == null || b == null){
            ViewData["tích"] = "Vui lòng nhập 2 số";
        } else {
            ViewData["tích"] = $"Tích của {a} và {b} là: {a * b}";

        }
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
