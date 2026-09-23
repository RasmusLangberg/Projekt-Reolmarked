using Projekt_Reolmarked.Model;

namespace Projekt_Reolmarked.Data;

public interface IUserRepository
{
    List<User> GetAll();
    void Add(User user);
    void Delete(int id);
}