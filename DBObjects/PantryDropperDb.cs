using MySqlConnector;

namespace recipe_box_squared;

public class PantryDropperDb : IDisposable
{
    public MySqlConnection Connection;

    public PantryDropperDb(string connectionString) 
    {
        Connection = new MySqlConnection(connectionString);
    }

    public void Dispose() => Connection.Dispose();
}
