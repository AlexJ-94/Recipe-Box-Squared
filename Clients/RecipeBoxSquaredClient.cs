namespace recipe_box_squared;
using Dapper;

public class RecipeBoxSquaredClient
{
    public RecipeBoxSquaredDb _db;

    public RecipeBoxSquaredClient(RecipeBoxSquaredDb db)
    {
        _db = db;
    }

    public async Task<IEnumerable<CookBook>> GetAllCookbooks()
    {
        using (var connection = _db.Connection)
        {
            var cookBooks = await connection.QueryAsync<CookBook>("SELECT * FROM cookbook");
            return cookBooks;
        }
    }
}
