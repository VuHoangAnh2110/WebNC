using MVC04.Data;
using MVC04.Models;

public class MemberRepository : IMemberRepository
{
    private readonly AppDbContext _context;
    
    public MemberRepository(AppDbContext context)
    {
        _context = context;
    }

    

}