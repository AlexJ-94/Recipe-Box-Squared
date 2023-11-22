using Dapper;
using MySqlConnector;
using recipe_box_squared.Models;

namespace recipe_box_squared.Clients;
public class PantryDropperClient
{
    public PantryDropperDb _db;

    public PantryDropperClient(PantryDropperDb db)
    {
        _db = db;
    }

        public async Task<IEnumerable<PantryItem>> GetAllPantryItems()
    {
        using (var connection = _db.Connection)
        {
            var pantryItems = await connection.QueryAsync<PantryItem>("SELECT * FROM pantry_item");
            return pantryItems;
        }
    }
}
