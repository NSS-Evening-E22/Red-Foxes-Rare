using Microsoft.EntityFrameworkCore;
using GroupRareAPI.Models;

    public class RareAPIDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<RareUser> RareUsers { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<UserTypeChangeRequest> UserTypeChangeRequests { get; set; }

    public RareAPIDbContext(DbContextOptions<RareAPIDbContext> context) : base(context)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RareUser>().HasMany(ru => ru.subscriptions)
            .WithOne(s => s.Follower)
           .HasForeignKey(s => s.FollowerId);

        modelBuilder.Entity<Category>().HasData(new Category[]
        {
        new Category {Id = 1, Label = "Label"},
        });
        modelBuilder.Entity<Comment>().HasData(new Comment[]
        {
        new Comment {Id = 1, AuthorId = 1, PostId = 1, Content = "Comment content", CreatedOn = DateTime.Now},
        });
        modelBuilder.Entity<Post>().HasData(new Post[]
        {
        new Post {Id = 1, RareUserId = 1, CategoryId = 1, Title = "Post", PublicationDate = DateTime.Now, ImageUrl = "Image", Content = "Post content", Approved = true},
        });
        modelBuilder.Entity<RareUser>().HasData(new RareUser[]
        {
        new RareUser {Id = 1, FirstName = "Bob", LastName = "Henton", Bio = "Hi", ProfileImageUrl = "Image", Email = "bob@email", CreateOn = DateTime.Now, Active = false, IsStaff = true, UID = "123"},
        new RareUser {Id = 2, FirstName = "Felix", LastName = "Mandez", Bio = "...", ProfileImageUrl = "Image", Email = "felix@coolcars.com", CreateOn = DateTime.Now, Active = true, IsStaff = true, UID = "456"},
        new RareUser {Id = 3, FirstName = "Kim", LastName = "Jim", Bio = "I rly like Jim UwU", ProfileImageUrl = "Image", Email = "kim@email", CreateOn = DateTime.Now, Active = true, IsStaff = false, UID = "789"},
        new RareUser {Id = 4, FirstName = "Slimothy", LastName = "James", Bio = "Im slim and im jim", ProfileImageUrl = "Image", Email = "slimjim", CreateOn = DateTime.Now, Active = true, IsStaff = false, UID = "321"},
        });
        modelBuilder.Entity<Reaction>().HasData(new Reaction[]
        {
        new Reaction {Id = 1, Label = "Heart", ImageUrl = "Image"},
        });
        modelBuilder.Entity<Subscription>().HasData(new Subscription[]
        {
        new Subscription {Id = 1, FollowerId = 2, AuthorId = 1, CreatedOn = DateTime.Now, EndedOn = DateTime.Now},
        });
        modelBuilder.Entity<Tag>().HasData(new Tag[]
        {
        new Tag {Id = 1, Label = "LOL"},
        });
        modelBuilder.Entity<UserTypeChangeRequest>().HasData(new UserTypeChangeRequest[]
        {
        new UserTypeChangeRequest {Id = 1, Action = "Remove", AdminOneId = 1, AdminTwoId = 2, ModifiedUserId = 3},
        });

        var postTag = modelBuilder.Entity("PostTag");
        postTag.HasData(
            new { PostsId = 1, TagsId = 1 });

    }
}

