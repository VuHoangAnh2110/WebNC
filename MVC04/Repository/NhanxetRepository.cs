using Microsoft.EntityFrameworkCore;
using MVC04.Data;
using MVC04.Models;

public class NhanxetRepository : INhanxetRepository
{
    private readonly AppDbContext _context;
    
    public NhanxetRepository(AppDbContext context)
    {
        _context = context;
    }

    public void AddComment(Nhanxet comment)
    {
        _context.tblNhanxet.Add(comment);
    }

    public List<Nhanxet> GetCommentsByProductId(int productId)
    {
        return _context.tblNhanxet.Where(c => c.FK_iProductID == productId).ToList();
    }

    public void Save()
    {
        try
        {
            _context.SaveChanges();
        }
        catch (DbUpdateException ex)
        {
            throw new Exception("Lỗi khi lưu dữ liệu: " + ex.InnerException?.Message, ex);
        }

    }

    
}