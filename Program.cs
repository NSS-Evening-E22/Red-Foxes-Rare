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

// Add a comment
app.MapPut("/posts/{id}/comment", (RareAPIDbContext db, Comment comment) =>
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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

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
app.MapPut("/posts/{postId}", (RareAPIDbContext db, int postId) =>
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

