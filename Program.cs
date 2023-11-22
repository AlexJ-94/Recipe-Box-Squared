using Dapper;
using MySqlConnector;
using recipe_box_squared;
using recipe_box_squared.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddTransient<RecipeBoxSquaredDb>(_ => new RecipeBoxSquaredDb(builder.Configuration.GetConnectionString("RecipeBoxSquared")));
builder.Services.AddTransient<PantryDropperDb>(_ => new PantryDropperDb(builder.Configuration.GetConnectionString("PantryDropper")));
//builder.Services.AddTransient(x => new MySqlConnection(builder.Configuration.GetConnectionString("RecipeBoxSquared")));

// var connString = "Server=192.168.0.44;User ID=Xander;Password=ImaCodingWizard69;Database=recipeboxsquared";
// var connection = new MySqlConnection(connString);
// var sqlquery = "SELECT * FROM cookbook;";
// await connection.OpenAsync();

// using (connection) {
//     var cookbooks = connection.Query<CookBook>(sqlquery);
// }



// using var command = new MySqlCommand("SELECT * FROM cookbook;", connection);
// using var reader = await command.ExecuteReaderAsync();
// while (await reader.ReadAsync())
// {
//     var value = reader.GetOrdinal("cookbook_name");
    
//     Console.WriteLine("bitch " + value);
//     // do something with 'value'
// }

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
