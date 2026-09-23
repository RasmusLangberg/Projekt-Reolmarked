using Dapper;
using Projekt_Reolmarked.Model;

namespace Projekt_Reolmarked.Data;

public class UserRepository : IUserRepository
{
    public List<User> GetAll()
    {
        using var connection = Database.GetConnection();

        var rows = connection.Query<UserRow>(
            "SELECT ID, FirstName, LastName, Email, PhoneNumber, MonthlyPayment FROM [User]");

        return rows.Select(row => new User(
            row.ID,
            row.FirstName,
            row.LastName,
            row.Email,
            row.PhoneNumber)
        {
            MonthlyPayment = row.MonthlyPayment
        }).ToList();
    }

    public void Add(User user)
    {
        using var connection = Database.GetConnection();

        var sql = """
                  INSERT INTO [User] (FirstName, LastName, Email, PhoneNumber, MonthlyPayment)
                  OUTPUT INSERTED.ID
                  VALUES (@FirstName, @LastName, @Email, @PhoneNumber, @MonthlyPayment)
                  """;

        user.Id = connection.Query<int>(sql, user).First();
    }

    public void Delete(int id)
    {
        using var connection = Database.GetConnection();

        connection.Execute(
            "DELETE FROM [User] WHERE ID = @Id",
            new { Id = id });
    }

    private class UserRow
    {
        public int ID { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public int PhoneNumber { get; set; }
        public int MonthlyPayment { get; set; }
    }
}