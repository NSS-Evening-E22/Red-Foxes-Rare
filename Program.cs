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

//Create a subscription
app.MapPost("/api/subscriptions", (RareAPIDbContext db, Subscription subscription) => 
{   subscription.CreatedOn = DateTime.Now;
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

//view reactions on a post
app.MapGet("/api/postreactions/{PostId}", (RareAPIDbContext db, int PostId) =>
{
    var post = db.Posts.SingleOrDefault(p => p.Id == PostId);
    if (post == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(post);
        
        
    
});



app.Run();

