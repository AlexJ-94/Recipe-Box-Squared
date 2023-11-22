using Microsoft.AspNetCore.Mvc;
using recipe_box_squared.Clients;

namespace recipe_box_squared.Controllers;

[ApiController]
[Route("[controller]")]
public class PantryController : ControllerBase
{
    public PantryDropperDb _db;

    public PantryController(PantryDropperDb db)
    {
        _db = db;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllPantryItems()
    {
        await _db.Connection.OpenAsync();
        var client = new PantryDropperClient(_db);
        var result = await client.GetAllPantryItems();
        return new OkObjectResult(result);
    }
}
