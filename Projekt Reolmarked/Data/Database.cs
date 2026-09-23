using Microsoft.Data.SqlClient;

namespace Projekt_Reolmarked.Data;

public static class Database
{
    public static SqlConnection GetConnection()
    {
        return new SqlConnection(
            "Server=tcp:reolmarkeddb.database.windows.net,1433;" +
            "Database=reolmarkeddb;" +
            "User ID=reolmarkeddb;" +
            "Password=Gruppe6.;" +
            "Encrypt=True;" +
            "TrustServerCertificate=False;"
        );
    }
}