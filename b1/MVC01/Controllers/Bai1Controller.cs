using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC01.Models;

namespace MVC01.Controllers;

public class Bai1Controller : Controller
{
    
    public IActionResult Index()
    {
        ViewData["thoigian"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        return View();
    }

    public IActionResult Welcome(string name) {
        if (string.IsNullOrEmpty(name)){
            name = "";
        }
        ViewData["xinchao"] = "Xin chào " + name;
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}
