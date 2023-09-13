using GroupRareAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<RareAPIDbContext>(builder.Configuration["RareAPIDbConnectionString"]);

// Set the JSON serializer options
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//View all categories
app.MapGet("/category", (RareAPIDbContext db) =>
{
    return db.Categories.ToList();
});

// Get Posts by Category
app.MapGet("/posts/categories/{CategoryId}", (int CategoryId, RareAPIDbContext db) =>
{
    var category = db.Categories.FirstOrDefault(c => c.Id == CategoryId);

    if (category == null)
    {
        return Results.NotFound("Category not found");
    }

    var postsInCategory = db.Posts
        .Where(p => p.CategoryId == CategoryId)
        .ToList();

    return Results.Ok(postsInCategory);
});

//Create New Category
app.MapPost("/categories", (Category category, RareAPIDbContext db) =>
{
    db.Categories.Add(category);
    db.SaveChanges();

    return Results.Created($"/category/{category.Id}", category);
});


app.Run();

