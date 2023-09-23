using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GroupRareAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddtoRareuserclasspost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 21, 21, 49, 48, 933, DateTimeKind.Local).AddTicks(1062));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublicationDate",
                value: new DateTime(2023, 9, 21, 21, 49, 48, 933, DateTimeKind.Local).AddTicks(1113));

            migrationBuilder.UpdateData(
                table: "RareUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateOn",
                value: new DateTime(2023, 9, 21, 21, 49, 48, 933, DateTimeKind.Local).AddTicks(1132));

            migrationBuilder.UpdateData(
                table: "RareUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateOn",
                value: new DateTime(2023, 9, 21, 21, 49, 48, 933, DateTimeKind.Local).AddTicks(1137));

            migrationBuilder.UpdateData(
                table: "RareUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateOn",
                value: new DateTime(2023, 9, 21, 21, 49, 48, 933, DateTimeKind.Local).AddTicks(1141));

            migrationBuilder.UpdateData(
                table: "RareUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateOn",
                value: new DateTime(2023, 9, 21, 21, 49, 48, 933, DateTimeKind.Local).AddTicks(1145));

            migrationBuilder.UpdateData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "EndedOn" },
                values: new object[] { new DateTime(2023, 9, 21, 21, 49, 48, 933, DateTimeKind.Local).AddTicks(1169), new DateTime(2023, 9, 21, 21, 49, 48, 933, DateTimeKind.Local).AddTicks(1171) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 21, 21, 48, 1, 385, DateTimeKind.Local).AddTicks(8362));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublicationDate",
                value: new DateTime(2023, 9, 21, 21, 48, 1, 385, DateTimeKind.Local).AddTicks(8437));

            migrationBuilder.UpdateData(
                table: "RareUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateOn",
                value: new DateTime(2023, 9, 21, 21, 48, 1, 385, DateTimeKind.Local).AddTicks(8469));

            migrationBuilder.UpdateData(
                table: "RareUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateOn",
                value: new DateTime(2023, 9, 21, 21, 48, 1, 385, DateTimeKind.Local).AddTicks(8474));

            migrationBuilder.UpdateData(
                table: "RareUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateOn",
                value: new DateTime(2023, 9, 21, 21, 48, 1, 385, DateTimeKind.Local).AddTicks(8478));

            migrationBuilder.UpdateData(
                table: "RareUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateOn",
                value: new DateTime(2023, 9, 21, 21, 48, 1, 385, DateTimeKind.Local).AddTicks(8482));

            migrationBuilder.UpdateData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "EndedOn" },
                values: new object[] { new DateTime(2023, 9, 21, 21, 48, 1, 385, DateTimeKind.Local).AddTicks(8528), new DateTime(2023, 9, 21, 21, 48, 1, 385, DateTimeKind.Local).AddTicks(8531) });
        }
    }
}
