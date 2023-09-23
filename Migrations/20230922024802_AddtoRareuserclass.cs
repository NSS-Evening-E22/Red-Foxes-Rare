using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GroupRareAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddtoRareuserclass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Posts",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Posts",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 19, 20, 31, 10, 176, DateTimeKind.Local).AddTicks(5458));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublicationDate",
                value: new DateTime(2023, 9, 19, 20, 31, 10, 176, DateTimeKind.Local).AddTicks(5517));

            migrationBuilder.UpdateData(
                table: "RareUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateOn",
                value: new DateTime(2023, 9, 19, 20, 31, 10, 176, DateTimeKind.Local).AddTicks(5536));

            migrationBuilder.UpdateData(
                table: "RareUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateOn",
                value: new DateTime(2023, 9, 19, 20, 31, 10, 176, DateTimeKind.Local).AddTicks(5577));

            migrationBuilder.UpdateData(
                table: "RareUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateOn",
                value: new DateTime(2023, 9, 19, 20, 31, 10, 176, DateTimeKind.Local).AddTicks(5580));

            migrationBuilder.UpdateData(
                table: "RareUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateOn",
                value: new DateTime(2023, 9, 19, 20, 31, 10, 176, DateTimeKind.Local).AddTicks(5584));

            migrationBuilder.UpdateData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "EndedOn" },
                values: new object[] { new DateTime(2023, 9, 19, 20, 31, 10, 176, DateTimeKind.Local).AddTicks(5616), new DateTime(2023, 9, 19, 20, 31, 10, 176, DateTimeKind.Local).AddTicks(5618) });
        }
    }
}
