using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GroupRareAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RareUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Bio = table.Column<string>(type: "text", nullable: false),
                    ProfileImageUrl = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    CreateOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    IsStaff = table.Column<bool>(type: "boolean", nullable: false),
                    UID = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RareUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RareUserId = table.Column<int>(type: "integer", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    PublicationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    Approved = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_RareUsers_RareUserId",
                        column: x => x.RareUserId,
                        principalTable: "RareUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FollowerId = table.Column<int>(type: "integer", nullable: false),
                    AuthorId = table.Column<int>(type: "integer", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscriptions_RareUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "RareUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subscriptions_RareUsers_FollowerId",
                        column: x => x.FollowerId,
                        principalTable: "RareUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTypeChangeRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Action = table.Column<string>(type: "text", nullable: false),
                    AdminOneId = table.Column<int>(type: "integer", nullable: false),
                    AdminTwoId = table.Column<int>(type: "integer", nullable: false),
                    ModifiedUserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypeChangeRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTypeChangeRequests_RareUsers_AdminOneId",
                        column: x => x.AdminOneId,
                        principalTable: "RareUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTypeChangeRequests_RareUsers_AdminTwoId",
                        column: x => x.AdminTwoId,
                        principalTable: "RareUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTypeChangeRequests_RareUsers_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "RareUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AuthorId = table.Column<int>(type: "integer", nullable: false),
                    PostId = table.Column<int>(type: "integer", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_RareUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "RareUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostReaction",
                columns: table => new
                {
                    RareUserId = table.Column<int>(type: "integer", nullable: false),
                    PostsId = table.Column<int>(type: "integer", nullable: false),
                    ReactionsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostReaction", x => new { x.RareUserId, x.PostsId, x.ReactionsId });
                    table.ForeignKey(
                        name: "FK_PostReaction_RareUsers_RareUserId",
                        column: x => x.RareUserId,
                        principalTable: "RareUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostReaction_Posts_PostsId",
                        column: x => x.PostsId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostReaction_Reactions_ReactionsId",
                        column: x => x.ReactionsId,
                        principalTable: "Reactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostTag",
                columns: table => new
                {
                    PostsId = table.Column<int>(type: "integer", nullable: false),
                    TagsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTag", x => new { x.PostsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_PostTag_Posts_PostsId",
                        column: x => x.PostsId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Label" },
                values: new object[] { 1, "Label" });

            migrationBuilder.InsertData(
                table: "RareUsers",
                columns: new[] { "Id", "Active", "Bio", "CreateOn", "Email", "FirstName", "IsStaff", "LastName", "ProfileImageUrl", "UID" },
                values: new object[,]
                {
                    { 1, false, "Hi", new DateTime(2023, 9, 12, 19, 23, 34, 790, DateTimeKind.Local).AddTicks(1109), "bob@email", "Bob", true, "Henton", "Image", "123" },
                    { 2, true, "...", new DateTime(2023, 9, 12, 19, 23, 34, 790, DateTimeKind.Local).AddTicks(1167), "felix@coolcars.com", "Felix", true, "Mandez", "Image", "456" },
                    { 3, true, "I rly like Jim UwU", new DateTime(2023, 9, 12, 19, 23, 34, 790, DateTimeKind.Local).AddTicks(1175), "kim@email", "Kim", false, "Jim", "Image", "789" },
                    { 4, true, "Im slim and im jim", new DateTime(2023, 9, 12, 19, 23, 34, 790, DateTimeKind.Local).AddTicks(1181), "slimjim", "Slimothy", false, "James", "Image", "321" }
                });

            migrationBuilder.InsertData(
                table: "Reactions",
                columns: new[] { "Id", "ImageUrl", "Label" },
                values: new object[] { 1, "Image", "Heart" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Label" },
                values: new object[] { 1, "LOL" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Approved", "CategoryId", "Content", "ImageUrl", "PublicationDate", "RareUserId", "Title" },
                values: new object[] { 1, true, 1, "Post content", "Image", new DateTime(2023, 9, 12, 19, 23, 34, 790, DateTimeKind.Local).AddTicks(873), 1, "Post" });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "AuthorId", "CreatedOn", "EndedOn", "FollowerId" },
                values: new object[] { 1, 1, new DateTime(2023, 9, 12, 19, 23, 34, 790, DateTimeKind.Local).AddTicks(1394), new DateTime(2023, 9, 12, 19, 23, 34, 790, DateTimeKind.Local).AddTicks(1399), 2 });

            migrationBuilder.InsertData(
                table: "UserTypeChangeRequests",
                columns: new[] { "Id", "Action", "AdminOneId", "AdminTwoId", "ModifiedUserId" },
                values: new object[] { 1, "Remove", 1, 2, 3 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedOn", "PostId" },
                values: new object[] { 1, 1, "Comment content", new DateTime(2023, 9, 12, 19, 23, 34, 789, DateTimeKind.Local).AddTicks(9848), 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AuthorId",
                table: "Comments",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostReaction_ReactionsId",
                table: "PostReaction",
                column: "ReactionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_RareUserId",
                table: "Posts",
                column: "RareUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTag_TagsId",
                table: "PostTag",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_AuthorId",
                table: "Subscriptions",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_FollowerId",
                table: "Subscriptions",
                column: "FollowerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTypeChangeRequests_AdminOneId",
                table: "UserTypeChangeRequests",
                column: "AdminOneId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTypeChangeRequests_AdminTwoId",
                table: "UserTypeChangeRequests",
                column: "AdminTwoId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTypeChangeRequests_ModifiedUserId",
                table: "UserTypeChangeRequests",
                column: "ModifiedUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "PostReaction");

            migrationBuilder.DropTable(
                name: "PostTag");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "UserTypeChangeRequests");

            migrationBuilder.DropTable(
                name: "Reactions");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "RareUsers");
        }
    }
}
