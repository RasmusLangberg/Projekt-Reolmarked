using Projekt_Reolmarked.Model;

namespace Projekt_Reolmarked.Data;

public interface ISellerRepository
{
    List<Seller> GetAll();
    void Add(Seller seller);
    void Delete(int id);
}