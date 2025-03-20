using MVC04.Data;
using MVC04.Models;

public interface IMemberRepository
{
    bool IsEmailExists(string email);
    Member GetMemberByCredentials(string username, string passwordHash);
    void AddMember(Member member);
    Member GetByEmail(string email);

}
