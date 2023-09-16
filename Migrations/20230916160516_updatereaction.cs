using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GroupRareAPI.Migrations
{
    public partial class updatereaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PostUserReaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PostId = table.Column<int>(type: "integer", nullable: false),
                    ReactionId = table.Column<int>(type: "integer", nullable: false),
                    RareUserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostUserReaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostUserReaction_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostUserReaction_RareUsers_RareUserId",
                        column: x => x.RareUserId,
                        principalTable: "RareUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostUserReaction_Reactions_ReactionId",
                        column: x => x.ReactionId,
                        principalTable: "Reactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 16, 12, 5, 15, 305, DateTimeKind.Local).AddTicks(2186));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublicationDate",
                value: new DateTime(2023, 9, 16, 12, 5, 15, 305, DateTimeKind.Local).AddTicks(2264));

            migrationBuilder.UpdateData(
                table: "RareUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateOn",
                value: new DateTime(2023, 9, 16, 12, 5, 15, 305, DateTimeKind.Local).AddTicks(2286));

            migrationBuilder.UpdateData(
                table: "RareUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateOn",
                value: new DateTime(2023, 9, 16, 12, 5, 15, 305, DateTimeKind.Local).AddTicks(2291));

            migrationBuilder.UpdateData(
                table: "RareUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateOn",
                value: new DateTime(2023, 9, 16, 12, 5, 15, 305, DateTimeKind.Local).AddTicks(2372));

            migrationBuilder.UpdateData(
                table: "RareUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateOn",
                value: new DateTime(2023, 9, 16, 12, 5, 15, 305, DateTimeKind.Local).AddTicks(2376));

            migrationBuilder.UpdateData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "EndedOn" },
                values: new object[] { new DateTime(2023, 9, 16, 12, 5, 15, 305, DateTimeKind.Local).AddTicks(2412), new DateTime(2023, 9, 16, 12, 5, 15, 305, DateTimeKind.Local).AddTicks(2414) });

            migrationBuilder.CreateIndex(
                name: "IX_PostUserReaction_PostId",
                table: "PostUserReaction",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostUserReaction_RareUserId",
                table: "PostUserReaction",
                column: "RareUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostUserReaction_ReactionId",
                table: "PostUserReaction",
                column: "ReactionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostUserReaction");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 12, 20, 23, 58, 173, DateTimeKind.Local).AddTicks(9554));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublicationDate",
                value: new DateTime(2023, 9, 12, 20, 23, 58, 173, DateTimeKind.Local).AddTicks(9698));

            migrationBuilder.UpdateData(
                table: "RareUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateOn",
                value: new DateTime(2023, 9, 12, 20, 23, 58, 173, DateTimeKind.Local).AddTicks(9740));

            migrationBuilder.UpdateData(
                table: "RareUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateOn",
                value: new DateTime(2023, 9, 12, 20, 23, 58, 173, DateTimeKind.Local).AddTicks(9748));

            migrationBuilder.UpdateData(
                table: "RareUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateOn",
                value: new DateTime(2023, 9, 12, 20, 23, 58, 173, DateTimeKind.Local).AddTicks(9755));

            migrationBuilder.UpdateData(
                table: "RareUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateOn",
                value: new DateTime(2023, 9, 12, 20, 23, 58, 173, DateTimeKind.Local).AddTicks(9760));

            migrationBuilder.UpdateData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "EndedOn" },
                values: new object[] { new DateTime(2023, 9, 12, 20, 23, 58, 173, DateTimeKind.Local).AddTicks(9836), new DateTime(2023, 9, 12, 20, 23, 58, 173, DateTimeKind.Local).AddTicks(9841) });
        }
    }
}
