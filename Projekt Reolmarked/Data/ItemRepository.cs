using Dapper;
using Projekt_Reolmarked.data;
using Projekt_Reolmarked.Data;
using Projekt_Reolmarked.Model;

namespace Projekt_Reolmarked;

public class ItemRepository : IItemRepository
{
    public void add(Item item)
    {
        using var connection = Database.GetConnection();

        var sql = """
                  INSERT INTO dbo.Item (SellerId, Name, Price)
                  OUTPUT INSERTED.ItemId
                  VALUES (@SellerId, @Name, @Price)
                  """;

        var values = new
        {
            SellerId = item.Seller.Id,
            Name = item.Name,
            Price = item.Price
        };

        item.ItemId = connection.QuerySingle<int>(sql, values);
    }

    public List<Item> GetAll()
    {
        using var connection = Database.GetConnection();

        var sellers = new SellerRepository().GetAll();

        var rows = connection.Query<ItemRow>(
            """
            SELECT ItemId, SellerId, Name, Price
            FROM dbo.Item
            WHERE IsSold = 0
            """);

        var items = new List<Item>();

        foreach (var row in rows)
        {
            var seller = sellers.First(
                seller => seller.Id == row.SellerId);

            var item = new Item(
                row.Name,
                seller,
                row.ItemId,
                (decimal)row.Price);

            items.Add(item);
        }

        return items;
    }

    public void MarkAsSold(int itemId)
    {
        using var connection = Database.GetConnection();

        connection.Execute(
            """
            UPDATE dbo.Item
            SET IsSold = 1
            WHERE ItemId = @ItemId
            """,
            new { ItemId = itemId });
    }

    private class ItemRow
    {
        public int ItemId { get; set; }
        public int SellerId { get; set; }
        public string Name { get; set; } = "";
        public decimal Price { get; set; }
    }
}