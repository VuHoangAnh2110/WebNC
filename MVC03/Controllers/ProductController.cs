using System.Diagnostics;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc;
using MVC03.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace MVC03.Controllers;

public class ProductController : Controller
{
    private const string CartSessionKey = "Cart";

    private readonly ILogger<HomeController> _logger;

    public ProductController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    // Hàm lấy giỏ hàng từ Session
    private List<CartModel> GetCartItems()
    {
        var cart = HttpContext.Session.GetString(CartSessionKey);
        return cart != null ? JsonSerializer.Deserialize<List<CartModel>>(cart) : new List<CartModel>();
    }

    // Hàm lưu giỏ hàng vào Session
    private void SaveCartItems(List<CartModel> cart)
    {
        HttpContext.Session.SetString(CartSessionKey, JsonSerializer.Serialize(cart));
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

    [HttpPost]
    public IActionResult AddToCart(int id)
    {
        var productModel = new ProductModel();
        var product = productModel.GetProducts().FirstOrDefault(p => p.ProductID == id);

        if (product == null)
        {
            return Json(new { success = false, message = "Sản phẩm không tồn tại!" });
        }

        var cart = GetCartItems();
        var cartItem = cart.FirstOrDefault(c => c.ProductID == id);

        if (cartItem != null)
        {
            cartItem.Quantity++;
        }
        else
        {
            cart.Add(new CartModel
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                ImageURL = product.ImageURL,
                ProductPrice = product.ProductPrice,
                Quantity = 1
            });
        }

        SaveCartItems(cart);
        return Json(new { success = true, message = "Đã thêm sản phẩm vào giỏ hàng!" });
    }

    public IActionResult Cart()
    {
        var cart = GetCartItems();
        return View(cart);
    }

    [HttpPost]
    public IActionResult RemoveFromCart(int id)
    {
        var cart = GetCartItems();
        var cartItem = cart.FirstOrDefault(c => c.ProductID == id);

        if (cartItem != null)
        {
            cart.Remove(cartItem);
            SaveCartItems(cart);
        }

        return Json(new { success = true, message = "Xóa mặt hàng thành công!" });
    }

        
    [HttpPost]
    public IActionResult UpdateCart(int id, int quantity)
    {
        var cart = GetCartItems();
        var cartItem = cart.FirstOrDefault(c => c.ProductID == id);

        if (cartItem != null && quantity > 0)
        {
            cartItem.Quantity = quantity;
            SaveCartItems(cart);
        }

        return Json(new { success = true, message = "Cập nhật số lượng thành công!" });
    }

    [HttpPost]
    public IActionResult ClearCart()
    {
        SaveCartItems(new List<CartModel>());
        return Json(new { success = true, message = "Làm mới giỏ hàng thành công!" });
    }

    [HttpGet]
    public IActionResult GetCartCount()
    {
        var cart = GetCartItems();
        int count = cart.Count; 
        return Json(new { count });
    }

   
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
