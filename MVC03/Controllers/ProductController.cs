using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC03.Models;

namespace MVC03.Controllers;

public class ProductController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public ProductController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult ProductList(){
        ProductModel model = new ProductModel();
        var products = model.GetProducts();
        return View(products);
    }

    public IActionResult ProductDetail (int id) {
        ProductModel model = new ProductModel();
        var products = model.GetProducts();
        var product = products.FirstOrDefault(p => p.ProductID == id);

        if (product == null) {
            return NotFound();
        }
        return View(product);
    }

   
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
