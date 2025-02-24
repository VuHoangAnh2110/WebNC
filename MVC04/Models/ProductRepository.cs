using MVC04.Data;
using MVC04.Models;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;
    
    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public void AddProduct(Product product)
    {
        _context.tblProducts.Add(product);
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public Product GetProductByName(string productName)
    {
        return _context.tblProducts.FirstOrDefault(p => p.ProductName == productName);
    }

    public List<Product> GetAllProducts()
    {
        return _context.tblProducts.ToList();
    }

    public Product GetProductById(int id)
    {
        return _context.tblProducts.FirstOrDefault(p => p.ProductID == id);
    }

    public void DeleteProduct(int id)
    {
        var product = _context.tblProducts.FirstOrDefault(p => p.ProductID == id);
        if (product != null)
        {
            _context.tblProducts.Remove(product);
        }
    }

}