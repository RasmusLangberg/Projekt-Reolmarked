using Dapper;
using Projekt_Reolmarked.Model;

namespace Projekt_Reolmarked.Data;

public class SellerRepository : ISellerRepository
{
    public List<Seller> GetAll()
    {
        using var connection = Database.GetConnection();

       
        var rows = connection.Query<SellerRow>(
            "SELECT ID, FirstName, LastName, Email, PhoneNumber, MonthlyPayment FROM [User]");
        

        return rows.Select(row => new Seller(
            row.ID,
            row.FirstName,
            row.LastName,
            row.Email,
            row.PhoneNumber)
        {
            MonthlyPayment = row.MonthlyPayment
        }).ToList();
        
    }

    public void Add(Seller seller)
    {
        using var connection = Database.GetConnection();

        var sql = """
                  INSERT INTO [Seller] (FirstName, LastName, Email, PhoneNumber, MonthlyPayment)
                  OUTPUT INSERTED.ID
                  VALUES (@FirstName, @LastName, @Email, @PhoneNumber, @MonthlyPayment)
                  """;

        seller.Id = connection.Query<int>(sql, seller).First();
    }

    public void Delete(int id)
    {
        using var connection = Database.GetConnection();

        connection.Execute(
            """
            UPDATE dbo.Shelf
            SET OwnerID = NULL,
                ShelfStatus = 1
            WHERE OwnerID = @Id;

            DELETE FROM [Seller]
            WHERE ID = @Id;
            """,
            new { Id = id });
    }

    private class SellerRow 
    {
        public int ID { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public int PhoneNumber { get; set; }
        public int MonthlyPayment { get; set; }
    }
}