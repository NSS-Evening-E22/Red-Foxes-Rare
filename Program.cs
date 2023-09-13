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


// Get all posts
app.MapGet("/posts", (RareAPIDbContext db) =>
{
    List<Post> posts = db.Posts
    .Include(p => p.RareUser)
    .Include(p => p.Category)
    .Include(p => p.Tags)
    .Include(p => p.Reactions).ToList();

    if (posts.Count == 0)
    {
        return Results.NotFound("There are no posts");
    }
    return Results.Ok(posts);
});

// Get single posts details
app.MapGet("/posts/{postId}", (RareAPIDbContext db, int postId) =>
{
    Post post = db.Posts
    .Include(p => p.RareUser)
    .Include(p => p.Category)
    .Include(p => p.Tags)
    .Include(p => p.Reactions)
    .FirstOrDefault(p => p.Id == postId);

    if (post == null)
    {
        return Results.NotFound("Post not found");
    }
    return Results.Ok(post);
});

// View current users posts
app.MapGet("/posts/users/{userId}", (RareAPIDbContext db, int userId) =>
{
    List<Post> posts = db.Posts
    .Include(p => p.RareUser)
    .Include(p => p.Category)
    .Include(p => p.Tags)
    .Include(p => p.Reactions)
    .Where(p => p.RareUserId == userId).ToList();
    if (posts.Count == 0)
    {
        return Results.NotFound("User has no posts");
    }
    return Results.Ok(posts);
});

// Create a post
app.MapPost("/posts", (RareAPIDbContext db, Post post) =>
{
    try
    {
        db.Posts.Add(post);
        db.SaveChanges();
        return Results.Created($"/posts/{post.Id}", post);
    }
    catch (DbUpdateException)
    {
        return Results.NotFound("Post was not created");
    }
});

// Edit a post
app.MapPut("/posts/{postId}", (RareAPIDbContext db, int postId, Post post) =>
{
    Post postToUpdate = db.Posts.FirstOrDefault(p => p.Id == postId);
    if (postToUpdate == null)
    {
        return Results.NotFound("This post was not found");
    }

    postToUpdate.RareUserId = post.RareUserId;
    postToUpdate.CategoryId = post.CategoryId;
    postToUpdate.Title = post.Title;
    postToUpdate.ImageUrl = post.ImageUrl;
    postToUpdate.Content = post.Content;
    postToUpdate.Approved = post.Approved;
    db.Update(postToUpdate);
    db.SaveChanges();
    return Results.Ok(postToUpdate);
});

// Delete a post
app.MapDelete("/posts/{postId}", (RareAPIDbContext db, int postId) =>
{
    Post post = db.Posts.FirstOrDefault(p => p.Id == postId);
    if (post == null)
    {
        return Results.NotFound("Post not found");
    }
    db.Remove(post);
    db.SaveChanges();
    return Results.NoContent();
});
app.Run();

