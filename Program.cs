using GroupRareAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using Swashbuckle.AspNetCore.SwaggerGen;

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

// Add a comment
app.MapPost("/posts/{id}/comment", (RareAPIDbContext db, Comment comment) =>
{
    db.Comments.Add(comment);
    db.SaveChanges();
    return Results.Created($"/comments/{comment.Id}", comment);
});

// Get a post's comments
app.MapGet("/posts/{id}/comment", (RareAPIDbContext db, int postId) =>
{
    var postComments = db.Comments.Where(c => c.PostId == postId).ToList();
    return Results.Ok(postComments);
});

// Edit a comment
app.MapPut("/posts/{id}/comment", (RareAPIDbContext db, int commentId, Comment comment) => 
{
    Comment commentToUpdate = db.Comments.FirstOrDefault(c => c.Id ==  commentId);
    if (commentToUpdate == null)
    {
        return Results.NotFound();
    }
    commentToUpdate.Content = comment.Content;
    db.SaveChanges();
    return Results.NoContent();
});

// Delete a comment
app.MapDelete("/posts/{id}/comment", (RareAPIDbContext db, int id) =>
{
    Comment commentToDelete = db.Comments.FirstOrDefault(c => c.Id == id);
    if (commentToDelete == null)
    {
        return Results.NotFound();
    }
    db.Comments.Remove(commentToDelete);
    db.SaveChanges();
    return Results.NoContent();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();

