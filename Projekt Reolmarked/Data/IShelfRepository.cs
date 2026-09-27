using Projekt_Reolmarked.Model;

namespace Projekt_Reolmarked.Data;

public interface IShelfRepository
{
    List<Shelf> GetAll(IEnumerable<Seller> users);
    void UpdateOwner(int shelfId, int? ownerId);
}