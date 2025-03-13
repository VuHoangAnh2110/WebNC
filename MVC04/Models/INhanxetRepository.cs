using MVC04.Data;
using MVC04.Models;

public interface INhanxetRepository
{
    void AddComment(Nhanxet comment);
    List<Nhanxet> GetCommentsByProductId(int productId);
    void Save();
}
