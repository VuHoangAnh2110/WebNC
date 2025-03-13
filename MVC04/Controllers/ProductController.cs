using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC04.Data;
using MVC04.Models;

namespace MVC04.Controllers;

public class ProductController : Controller
{
    private readonly AppDbContext _context;
    private readonly IProductRepository _productRepository;
    private readonly INhanxetRepository _nhanxetRepository;

    // Gộp cả hai dependency vào một constructor
    public ProductController(AppDbContext context, IProductRepository productRepository, INhanxetRepository nhanxetRepository)
    {
        _context = context;
        _productRepository = productRepository;
        _nhanxetRepository = nhanxetRepository;
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

    public IActionResult ProductList(){
        var products = _productRepository.GetAllProducts();
        return View(products);
    }

    public IActionResult ProductDetail (int id) {
        var product = _productRepository.GetProductById(id);

        if (product == null) {
            return NotFound();
        }

        var comments = _nhanxetRepository.GetCommentsByProductId(id);

        // Gán danh sách bình luận vào ViewBag
        ViewBag.Comments = comments;

        return View(product);
    }

    // Nhận xét của tài khoản
    [HttpPost]
    public IActionResult AddComment([FromBody] Nhanxet commentData)
    {
        try
        {
            if (commentData == null || string.IsNullOrWhiteSpace(commentData.sNoidung))
            {
                return Json(new { success = false, message = "Nội dung bình luận không được để trống." });
            }

            var product = _productRepository.GetProductById(commentData.FK_iProductID);
            if (product == null)
            {
                return Json(new { success = false, message = "Sản phẩm không tồn tại." });
            }

            var newComment = new Nhanxet
            {
                sNoidung = commentData.sNoidung,
                tThoigianGhinhan = DateTime.Now,
                FK_iProductID = commentData.FK_iProductID,
                FK_MemberName = commentData.FK_MemberName
            };

            _nhanxetRepository.AddComment(newComment);
            _nhanxetRepository.Save();

            return Json(new
            {
                success = true,
                message = "Bình luận đã được lưu.",
                comment = new
                {
                    user = newComment.FK_MemberName,
                    content = newComment.sNoidung,
                    time = newComment.tThoigianGhinhan.ToString("dd/MM/yyyy HH:mm")
                }
            });
        }
        catch (Exception ex)
        {
            var newComment1 = new Nhanxet
            {
                sNoidung = commentData.sNoidung,
                tThoigianGhinhan = DateTime.Now,
                FK_iProductID = commentData.FK_iProductID,
                FK_MemberName = commentData.FK_MemberName
            };

            return Json(new { success = false, message = "Lỗi server: " + ex.Message + newComment1.sNoidung});
        }
    }

}
