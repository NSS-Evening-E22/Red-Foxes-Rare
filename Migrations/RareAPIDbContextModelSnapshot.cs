﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GroupRareAPI.Migrations
{
    [DbContext(typeof(RareAPIDbContext))]
    partial class RareAPIDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GroupRareAPI.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Label = "Label"
                        });
                });

            modelBuilder.Entity("GroupRareAPI.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("PostId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("PostId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            Content = "Comment content",
                            CreatedOn = new DateTime(2023, 9, 12, 20, 23, 58, 173, DateTimeKind.Local).AddTicks(9554),
                            PostId = 1
                        });
                });

            modelBuilder.Entity("GroupRareAPI.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Approved")
                        .HasColumnType("boolean");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("RareUserId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("RareUserId");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Approved = true,
                            CategoryId = 1,
                            Content = "Post content",
                            ImageUrl = "Image",
                            PublicationDate = new DateTime(2023, 9, 12, 20, 23, 58, 173, DateTimeKind.Local).AddTicks(9698),
                            RareUserId = 1,
                            Title = "Post"
                        });
                });

            modelBuilder.Entity("GroupRareAPI.Models.RareUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsStaff")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProfileImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("RareUsers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = false,
                            Bio = "Hi",
                            CreateOn = new DateTime(2023, 9, 12, 20, 23, 58, 173, DateTimeKind.Local).AddTicks(9740),
                            Email = "bob@email",
                            FirstName = "Bob",
                            IsStaff = true,
                            LastName = "Henton",
                            ProfileImageUrl = "Image",
                            UID = "123"
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
                            Bio = "...",
                            CreateOn = new DateTime(2023, 9, 12, 20, 23, 58, 173, DateTimeKind.Local).AddTicks(9748),
                            Email = "felix@coolcars.com",
                            FirstName = "Felix",
                            IsStaff = true,
                            LastName = "Mandez",
                            ProfileImageUrl = "Image",
                            UID = "456"
                        },
                        new
                        {
                            Id = 3,
                            Active = true,
                            Bio = "I rly like Jim UwU",
                            CreateOn = new DateTime(2023, 9, 12, 20, 23, 58, 173, DateTimeKind.Local).AddTicks(9755),
                            Email = "kim@email",
                            FirstName = "Kim",
                            IsStaff = false,
                            LastName = "Jim",
                            ProfileImageUrl = "Image",
                            UID = "789"
                        },
                        new
                        {
                            Id = 4,
                            Active = true,
                            Bio = "Im slim and im jim",
                            CreateOn = new DateTime(2023, 9, 12, 20, 23, 58, 173, DateTimeKind.Local).AddTicks(9760),
                            Email = "slimjim",
                            FirstName = "Slimothy",
                            IsStaff = false,
                            LastName = "James",
                            ProfileImageUrl = "Image",
                            UID = "321"
                        });
                });

            modelBuilder.Entity("GroupRareAPI.Models.Reaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Reactions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageUrl = "Image",
                            Label = "Heart"
                        });
                });

            modelBuilder.Entity("GroupRareAPI.Models.Subscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("EndedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("FollowerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("FollowerId");

                    b.ToTable("Subscriptions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            CreatedOn = new DateTime(2023, 9, 12, 20, 23, 58, 173, DateTimeKind.Local).AddTicks(9836),
                            EndedOn = new DateTime(2023, 9, 12, 20, 23, 58, 173, DateTimeKind.Local).AddTicks(9841),
                            FollowerId = 2
                        });
                });

            modelBuilder.Entity("GroupRareAPI.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Label = "LOL"
                        });
                });

            modelBuilder.Entity("GroupRareAPI.Models.UserTypeChangeRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("AdminOneId")
                        .HasColumnType("integer");

                    b.Property<int>("AdminTwoId")
                        .HasColumnType("integer");

                    b.Property<int>("ModifiedUserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AdminOneId");

                    b.HasIndex("AdminTwoId");

                    b.HasIndex("ModifiedUserId");

                    b.ToTable("UserTypeChangeRequests");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Action = "Remove",
                            AdminOneId = 1,
                            AdminTwoId = 2,
                            ModifiedUserId = 3
                        });
                });

            modelBuilder.Entity("PostReaction", b =>
                {
                    b.Property<int>("PostsId")
                        .HasColumnType("integer");

                    b.Property<int>("ReactionsId")
                        .HasColumnType("integer");

                    b.HasKey("PostsId", "ReactionsId");

                    b.HasIndex("ReactionsId");

                    b.ToTable("PostReaction");
                });

            modelBuilder.Entity("PostTag", b =>
                {
                    b.Property<int>("PostsId")
                        .HasColumnType("integer");

                    b.Property<int>("TagsId")
                        .HasColumnType("integer");

                    b.HasKey("PostsId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("PostTag");

                    b.HasData(
                        new
                        {
                            PostsId = 1,
                            TagsId = 1
                        });
                });

            modelBuilder.Entity("GroupRareAPI.Models.Comment", b =>
                {
                    b.HasOne("GroupRareAPI.Models.RareUser", "Author")
                        .WithMany("Comments")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GroupRareAPI.Models.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("GroupRareAPI.Models.Post", b =>
                {
                    b.HasOne("GroupRareAPI.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GroupRareAPI.Models.RareUser", "RareUser")
                        .WithMany()
                        .HasForeignKey("RareUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("RareUser");
                });

            modelBuilder.Entity("GroupRareAPI.Models.Subscription", b =>
                {
                    b.HasOne("GroupRareAPI.Models.RareUser", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GroupRareAPI.Models.RareUser", "Follower")
                        .WithMany("Subscriptions")
                        .HasForeignKey("FollowerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Follower");
                });

            modelBuilder.Entity("GroupRareAPI.Models.UserTypeChangeRequest", b =>
                {
                    b.HasOne("GroupRareAPI.Models.RareUser", "AdminOne")
                        .WithMany()
                        .HasForeignKey("AdminOneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GroupRareAPI.Models.RareUser", "AdminTwo")
                        .WithMany()
                        .HasForeignKey("AdminTwoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GroupRareAPI.Models.RareUser", "ModifiedUser")
                        .WithMany()
                        .HasForeignKey("ModifiedUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AdminOne");

                    b.Navigation("AdminTwo");

                    b.Navigation("ModifiedUser");
                });

            modelBuilder.Entity("PostReaction", b =>
                {
                    b.HasOne("GroupRareAPI.Models.Post", null)
                        .WithMany()
                        .HasForeignKey("PostsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GroupRareAPI.Models.Reaction", null)
                        .WithMany()
                        .HasForeignKey("ReactionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PostTag", b =>
                {
                    b.HasOne("GroupRareAPI.Models.Post", null)
                        .WithMany()
                        .HasForeignKey("PostsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GroupRareAPI.Models.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GroupRareAPI.Models.RareUser", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Subscriptions");
                });
#pragma warning restore 612, 618
        }
    }
}
