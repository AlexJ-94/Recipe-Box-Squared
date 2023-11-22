using MySqlConnector;

namespace recipe_box_squared;

public class RecipeBoxSquaredDb : IDisposable
{
    public MySqlConnection Connection;

    public RecipeBoxSquaredDb(string connectionString) 
    {
        Connection = new MySqlConnection(connectionString);
    }

    public void Dispose() => Connection.Dispose();
}
