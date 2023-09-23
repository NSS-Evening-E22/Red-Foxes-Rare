using GroupRareAPI.DTO;
using GroupRareAPI.Models;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var DefaultCors = "_DefaultCors";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: DefaultCors,

        policy =>
        {
            policy.WithOrigins("http://localhost:3000",
                                "http://localhost:7033")
                                .AllowAnyHeader()
                                .AllowAnyMethod()
                                .AllowAnyOrigin();
        });
});


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

app.UseCors(DefaultCors);

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
    Comment commentToUpdate = db.Comments.FirstOrDefault(c => c.Id == commentId);
    if (commentToUpdate == null)
    {
        return Results.NotFound();
    }
    commentToUpdate.Content = comment.Content;
    db.SaveChanges();
    return Results.NoContent();
});

//List Posts by User Profile
app.MapGet("/api/RareUser/{userId}/Posts", (int Id, RareAPIDbContext db) =>
{
    var rareUser = db.RareUsers.FirstOrDefault(user => user.Id == Id);

    if (rareUser == null)
    {
        return Results.NotFound("RareUser not found.");
    }

    var userPosts = db.Posts.Where(post => post.RareUserId == Id).ToList();

    return Results.Json(userPosts);
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


//Create a subscription
app.MapPost("/api/subscriptions", (RareAPIDbContext db, Subscription subscription) =>
{
    subscription.CreatedOn = DateTime.Now;
    subscription.EndedOn = DateTime.Now.AddMonths(6);
    db.Subscriptions.Add(subscription);
    db.SaveChanges();
    return Results.Created($"/api/subscriptions/{subscription.Id}", subscription);
});

//update a subscription to add a endedOn time
app.MapPut("/api/subscriptions/{id}", (RareAPIDbContext db, int id, Subscription subscription) =>

{
    Subscription subscriptionToUpdate = db.Subscriptions.SingleOrDefault(s => s.Id == id);
    if (subscriptionToUpdate == null)
    {
        return Results.Ok(subscription);
    }
    subscriptionToUpdate.EndedOn = DateTime.Now;
    db.SaveChanges();
    return Results.NoContent();
});

//create a new reaction
app.MapPost("/api/reactions", (RareAPIDbContext db, Reaction reaction) =>
{
    db.Reactions.Add(reaction);
    db.SaveChanges();
    return Results.Created($"/api/reactions/{reaction.Id}", reaction);

});

//create a postreaction to postreaction table
app.MapPost("/api/postuserreaction", (RareAPIDbContext db, PostReaction postUserReaction) =>
{
    db.PostUserReaction.Add(postUserReaction);
    return Results.Ok();
});

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

//Delete Category
app.MapDelete("/api/categories/{Id}", (int Id, RareAPIDbContext db) =>
{
    Category category = db.Categories.FirstOrDefault(c => c.Id == Id);

    if (category == null)
    {
        return Results.NotFound();
    }

    db.Categories.Remove(category);
    db.SaveChanges();

    return Results.Ok(category);
});
//Edit a Category 
app.MapPut("/category/{CategoryId}", (int Id, Category updatedCategory, RareAPIDbContext db) =>
{
    Category existingCategory = db.Categories.FirstOrDefault(c => c.Id == Id);

    if (existingCategory == null)
    {
        return Results.NotFound();
    }

    existingCategory.Label = updatedCategory.Label;

    db.SaveChanges();

    return Results.Ok(existingCategory);
});

//View single user profile details

app.MapGet("/rareusers/{Id}", (string UID, RareAPIDbContext db) =>
{
    RareUser rareUser = db.RareUsers.FirstOrDefault(u => u.UID == UID);

    if (rareUser == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(rareUser);
});

//View all user porfile
app.MapGet("/rareusers", (RareAPIDbContext db) =>
{
    var usersAlphabetical = db.RareUsers.OrderBy(user => user.FirstName).ToList();
    return usersAlphabetical;
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
app.MapPost("/post", (RareAPIDbContext db, CreatePostDTO post) =>
{
    Post newPost = new()
    {
        ImageUrl = post.ImageUrl,
        Content = post.Content,
        Title = post.Title,
    };
    newPost.RareUser = db.RareUsers.FirstOrDefault(x => x.UID == post.RareUserId);
    newPost.Category = db.Categories.FirstOrDefault(c => c.Id == post.CategoryId);

    db.Add(newPost);
    db.SaveChanges();
    return Results.Created($"/posts/", post);
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


//create a postreaction to postreaction table
app.MapPost("/api/postreaction", (RareAPIDbContext db, int PostId, int RareUserId, int ReactionId) => 
{
    var Post = db.Posts.SingleOrDefault(p => p.Id == PostId);
    var User = db.RareUsers.SingleOrDefault(u => u.Id == RareUserId);
    var Reaction = db.Reactions.SingleOrDefault(r => r.Id == ReactionId);

    PostReaction postReaction = new PostReaction() 
    {
        Post = Post,
        RareUser = User,
        Reaction = Reaction
    };

    db.PostUserReaction.Add(postReaction);
    db.SaveChanges();
    return Results.NoContent();
});

// View posts from subscribed users
app.MapGet("/home/subscribed/{followerId}", (RareAPIDbContext db, int userId) =>
{
    List<int> subscribedUserIds = db.Subscriptions
    .Where(sub => sub.FollowerId == userId)
    .Select(sub => sub.AuthorId)
    .ToList();

    var posts = db.Posts
    .Include(p => p.RareUser)
    .Include(p => p.Category)
    .Include(p => p.Tags)
    .Include(p => p.Reactions)
    .Where(p => subscribedUserIds.Contains(p.RareUserId));

    return Results.Ok(posts);
});

//TAGS ENDPOINTS
//CREATE tag
app.MapPost("/tags", (RareAPIDbContext db, Tag tag) =>
{
    try
    {
        db.Tags.Add(tag);
        db.SaveChanges();
        return Results.Created($"/tags/{tag.Id}", tag);
    }
    catch (DbUpdateException)
    {
        return Results.NotFound();
    }
});

//GET all tags
app.MapGet("/tags", (RareAPIDbContext db) =>
{
    return db.Tags.ToList();
});

//UPDATE tag
app.MapPut("/tags/{id}", (RareAPIDbContext db, int id, Tag tag) =>
{
    Tag tagToUpdate = db.Tags.SingleOrDefault(tag => tag.Id == id);
    if (tagToUpdate == null)
    {
        return Results.NotFound();
    }
    tagToUpdate.Label = tag.Label;

    db.Update(tagToUpdate);
    db.SaveChanges();
    return Results.Ok(tagToUpdate);
});

//DELETE tag
app.MapDelete("/tags/{id}", (RareAPIDbContext db, int id) =>
{
    Tag tag = db.Tags.SingleOrDefault(tag => tag.Id == id);
    if (tag == null)
    {
        return Results.NotFound();
    }
    db.Tags.Remove(tag);
    db.SaveChanges();
    return Results.NoContent();
});
 

//POST/add tag to post
app.MapPost("/posttag", (int PostId, int TagId, RareAPIDbContext db) =>
{
    var post = db.Posts.Include(p => p.Tags).FirstOrDefault(p => p.Id == PostId);


    if (post == null)
    {
        return Results.NotFound();
    }   

    var tagToAdd = db.Tags.FirstOrDefault(t => t.Id == TagId);

    if (tagToAdd == null)
    {
        return Results.NotFound();
    }

    post.Tags.Add(tagToAdd);
    db.SaveChanges();

    return Results.Ok();
});

//DELETE tag from post
app.MapDelete("/posttag/{id}", (int PostId, int TagId, RareAPIDbContext db) =>
{
    var post = db.Posts.Include(p => p.Tags).FirstOrDefault(p => p.Id == PostId);

    if (post == null)
    {
        return Results.NotFound();
    }

    var tagToRemove = db.Tags.FirstOrDefault(t => t.Id == TagId);

    if (tagToRemove == null)
    {
        return Results.NotFound();
    }

    post.Tags.Remove(tagToRemove);
    db.SaveChanges();

    return Results.NoContent();
});

//GET/search tags
app.MapGet("/tags/{id}", (RareAPIDbContext db, string tag) =>
{
    // Find the Tag by name (you can also use tagId if you prefer)
    var tagEntity = db.Tags.FirstOrDefault(t => t.Label == tag);
    if (tagEntity == null)
    {
        return Results.NotFound("Tag not found.");
    }
    // Retrieve posts associated with the tag
    var postsByTag = db.Posts
        .Where(post => post.Tags.Any(t => t.Id == tagEntity.Id))
        .ToList();
    if (postsByTag.Count == 0)
    {
        return Results.NotFound("No posts found for this tag.");
    }
    // Return the posts associated with the tag as JSON
    return Results.Json(postsByTag);
});

app.MapGet("/checkuser/{uid}", (RareAPIDbContext db, string uid) =>
{
    var userExist = db.RareUsers.Where(x => x.UID == uid).ToList();
    if (userExist == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(userExist);
});

app.MapPost("/register", (RareAPIDbContext db, RareUser user) =>
{
    db.RareUsers.Add(user);
    db.SaveChanges();
    return Results.Created($"/api/user/user.Id", user);
});

app.MapGet("/api/users", (RareAPIDbContext db) =>
{
    return db.RareUsers.ToList();
});


app.Run();

