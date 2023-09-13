using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GroupRareAPI.Migrations
{
    public partial class DataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 12, 20, 23, 58, 173, DateTimeKind.Local).AddTicks(9554));

            migrationBuilder.InsertData(
                table: "PostTag",
                columns: new[] { "PostsId", "TagsId" },
                values: new object[] { 1, 1 });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PostTag",
                keyColumns: new[] { "PostsId", "TagsId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2023, 9, 12, 19, 23, 34, 789, DateTimeKind.Local).AddTicks(9848));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublicationDate",
                value: new DateTime(2023, 9, 12, 19, 23, 34, 790, DateTimeKind.Local).AddTicks(873));

            migrationBuilder.UpdateData(
                table: "RareUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateOn",
                value: new DateTime(2023, 9, 12, 19, 23, 34, 790, DateTimeKind.Local).AddTicks(1109));

            migrationBuilder.UpdateData(
                table: "RareUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateOn",
                value: new DateTime(2023, 9, 12, 19, 23, 34, 790, DateTimeKind.Local).AddTicks(1167));

            migrationBuilder.UpdateData(
                table: "RareUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateOn",
                value: new DateTime(2023, 9, 12, 19, 23, 34, 790, DateTimeKind.Local).AddTicks(1175));

            migrationBuilder.UpdateData(
                table: "RareUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateOn",
                value: new DateTime(2023, 9, 12, 19, 23, 34, 790, DateTimeKind.Local).AddTicks(1181));

            migrationBuilder.UpdateData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "EndedOn" },
                values: new object[] { new DateTime(2023, 9, 12, 19, 23, 34, 790, DateTimeKind.Local).AddTicks(1394), new DateTime(2023, 9, 12, 19, 23, 34, 790, DateTimeKind.Local).AddTicks(1399) });
        }
    }
}
