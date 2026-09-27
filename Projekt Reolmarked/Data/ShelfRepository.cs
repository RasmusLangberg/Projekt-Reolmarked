using Dapper;
using Projekt_Reolmarked.Model;

namespace Projekt_Reolmarked.Data;

public class ShelfRepository : IShelfRepository
{
    public List<Shelf> GetAll(IEnumerable<Seller> users)
    {
        using var connection = Database.GetConnection();

        var rows = connection.Query<ShelfRow>(
            """
            SELECT ID, OwnerID, ShelfType, ShelfStatus, ShelfPrice
            FROM dbo.Shelf
            ORDER BY ID
            """);

        var shelves = new List<Shelf>();

        foreach (var row in rows)
        {
            var owner = users.FirstOrDefault(
                user => user.Id == row.OwnerID);

            var shelf = new Shelf(
                row.ID,
                owner,
                (EnumShelfType)row.ShelfType,
                row.ShelfPrice,
                (EnumShelfStatus)row.ShelfStatus);

            shelves.Add(shelf);
        }

        return shelves;
    }

    public void UpdateOwner(int shelfId, int? ownerId)
    {
        using var connection = Database.GetConnection();

        connection.Execute(
            """
            UPDATE dbo.Shelf
            SET OwnerID = @OwnerID,
                ShelfStatus = CASE
                    WHEN @OwnerID IS NULL THEN 1
                    ELSE 2
                END
            WHERE ID = @ShelfID
            """,
            new { ShelfID = shelfId, OwnerID = ownerId });
    }

    private class ShelfRow
    {
        public int ID { get; set; }
        public int? OwnerID { get; set; }
        public int ShelfType { get; set; }
        public int ShelfStatus { get; set; }
        public int ShelfPrice { get; set; }
    }
}