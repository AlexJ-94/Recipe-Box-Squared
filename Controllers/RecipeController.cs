using Microsoft.AspNetCore.Mvc;

namespace recipe_box_squared.Controllers;

[ApiController]
[Route("[controller]")]
public class RecipeController : ControllerBase
{
    public RecipeBoxSquaredDb _db;

    public RecipeController(RecipeBoxSquaredDb db)
    {
        _db = db;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllCookBooks()
    {
        await _db.Connection.OpenAsync();
        var client = new RecipeBoxSquaredClient(_db);
        var result = await client.GetAllCookbooks();
        return new OkObjectResult(result);
    }
}
