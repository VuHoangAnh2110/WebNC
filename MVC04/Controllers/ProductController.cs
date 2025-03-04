using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC04.Data;
using MVC04.Models;

namespace MVC04.Controllers;

public class ProductController : Controller
{
    private readonly AppDbContext _context;
    private readonly IProductRepository _productRepository;

    // Gộp cả hai dependency vào một constructor
    public ProductController(AppDbContext context, IProductRepository productRepository)
    {
        _context = context;
        _productRepository = productRepository;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult NewProduct()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Product product)
    {
        if (!ModelState.IsValid)
        {
            return View("NewProduct", product);
        }

        var existingProduct = _productRepository.GetProductByName(product.ProductName);
        if (existingProduct != null)
        {
            ModelState.AddModelError("ProductName", "Tên sản phẩm đã tồn tại.");
            return View("NewProduct", product);
        }

        if (product.ProductPrice < 0)
        {
            ModelState.AddModelError("ProductPrice", "Giá sản phẩm không thể âm.");
            return View("NewProduct", product);
        }

        _productRepository.AddProduct(product);
        _productRepository.Save();

        TempData["SuccessMessage"] = "Sản phẩm đã được thêm thành công!";
        return RedirectToAction("NewProduct");
    }

    [HttpGet]
    public IActionResult ProductMgr()
    {
        var products = _productRepository.GetAllProducts();
        return View(products);
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var product = _productRepository.GetProductById(id);
        if (product != null)
        {
            _productRepository.DeleteProduct(id);
            _productRepository.Save();
            TempData["SuccessMessage"] = "Sản phẩm đã được xóa thành công!";
        }
        else
        {
            TempData["ErrorMessage"] = "Không tìm thấy sản phẩm!";
        }

        return RedirectToAction("ProductMgr");
    }

    [HttpGet]
    public IActionResult DeleteAjax (int id) {
        var product = _productRepository.GetProductById(id);
        if (product != null) {
            _productRepository.DeleteProduct(id);
            _productRepository.Save();
            return Json(new {success = true, message = "Xóa sản phẩm thành công."});
        } else {
            return Json(new {success = false, message = "Xóa sản phẩm không thành công."});
        }
    }

    public IActionResult Giamgia (int id){
        var product = _productRepository.GetProductById(id);
        var gia = 1;
        if (product != null) {
            if (product.ProductPrice >= 100000){
                gia = (int)(product.ProductPrice * 0.9m);
            }
            return Json(new { success = true, giaMoi = gia });
        } else {
            return Json(new { success = false, message = "Lỗi giảm giá." });
        }
    }

    [HttpPost]
    public IActionResult GiamgiaAjax (int id) {
        var product = _productRepository.GetProductById(id);
        if (product != null) {
            if (product.ProductPrice >= 100000)
            {
                product.ProductPrice = (int)(product.ProductPrice * 0.9m); 
                _productRepository.Save(); 

                return Json(new { success = true, giaMoi = product.ProductPrice });
            } else {
                return Json(new { success = false, message = "Không đủ điều kiện giảm giá." });
            }
        } else {
            return Json(new { success = false, message = "Sản phẩm không tồn tại." });
        }
    }

}
