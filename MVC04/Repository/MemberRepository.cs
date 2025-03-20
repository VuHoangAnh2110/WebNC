using MVC04.Data;
using MVC04.Models;

public class MemberRepository : IMemberRepository
{
    private readonly AppDbContext _context;
    
    public MemberRepository(AppDbContext context)
    {
        _context = context;
    }

    public bool IsEmailExists(string email)
    {
        return _context.tblMembers.Any(m => m.Email == email);
    }

    public Member GetMemberByCredentials(string username, string passwordHash)
    {
        return _context.tblMembers.SingleOrDefault(m => m.MemberID == username && m.PasswordHash == passwordHash);
    }

    public void AddMember(Member member)
    {
        _context.tblMembers.Add(member);
        _context.SaveChanges();
    }
    
    public Member GetByEmail(string email)
    {
        return _context.tblMembers.SingleOrDefault(m => m.Email == email);
    }

}