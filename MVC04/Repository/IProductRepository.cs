using MVC04.Data;
using MVC04.Models;

public interface IProductRepository
{
    void AddProduct(Product product);
    List<Product> GetAllProducts();
    Product GetProductByName(string productName);
    Product GetProductById(int id);  
    void DeleteProduct(int id);  
    void Save();
}
