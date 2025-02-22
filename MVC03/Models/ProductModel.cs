using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC03.Models;

public class Product {
    
    [Required(ErrorMessage = "Không được để trống")]
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public string ImageURL { get; set; }
    public string Description { get; set; }
    public decimal ProductPrice { get; set; }


}

public class ProductModel {
    public List<Product> GetProducts(){
        return new List<Product> {
            new Product {ProductID = 1, ProductName = "Quả chuối vàng", ImageURL = "/image/chuoi.jpg", ProductPrice = 150000m, Description = "Vàng và cong, ngọt vị chuối"},
            new Product {ProductID = 2, ProductName = "Quả dứa", ImageURL = "/image/dua.png", ProductPrice = 12300m, Description = "Hơi chua và có thể ăn với muối ớt"},
            new Product {ProductID = 3, ProductName = "Bắp ngô", ImageURL = "/image/ngo.jpg", ProductPrice = 14000m, Description = "Ngô ngọt có thể ăn lẩu và nướng"},
            new Product {ProductID = 4, ProductName = "Quả bí đỏ", ImageURL = "/image/bi.jpg", ProductPrice = 152300m, Description = "Bí có nấu canh xương và chế biến,..."},
            new Product {ProductID = 5, ProductName = "Quả bưởi xanh", ImageURL = "/image/buoi.jpg", ProductPrice = 1200m, Description = "Loại quả phổ biến và cung cấp nước"},
            new Product {ProductID = 6, ProductName = "Quả bơ", ImageURL = "/image/bo.jpg", ProductPrice = 123000m, Description = "Thông thường được làm sinh tố giải khát"},
            new Product {ProductID = 7, ProductName = "Quả dâu tây", ImageURL = "/image/dau.jpg", ProductPrice = 150000m, Description = "Sử dụng khi làm bánh và chế biến ..."},
            new Product {ProductID = 8, ProductName = "Quả sầu riêng", ImageURL = "/image/sau.jpg", ProductPrice = 143400m, Description = "Vị ngọt, thơm nhưng hơi khó ngửi ..."},
            new Product {ProductID = 9, ProductName = "Trái dâu tằm", ImageURL = "/image/dautam.jpg", ProductPrice = 430000m, Description = "Có vị hơi chua khi chưa chín, làm nước ngâm"},
            new Product {ProductID = 10, ProductName = "Quả chuối", ImageURL = "/image/chuoi.jpg", ProductPrice = 150000m, Description = "Vàng và Cong"},
            new Product {ProductID = 11, ProductName = "Quả bí ngô", ImageURL = "/image/bi.jpg", ProductPrice = 43000m, Description = "Vàng và Cong"}

        };
    }
}