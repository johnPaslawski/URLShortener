using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace URLShortener.EFCore.Migrations
{
    public partial class guid_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reports",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AddColumn<string>(
                name: "Guid",
                table: "Links",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Links");

            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "Id", "GenuineURL", "ShortenedURL" },
                values: new object[,]
                {
                    { 1, "https://www.youtube.com/watch?v=3QbaTfN0-8s", "short/url/1" },
                    { 2, "https://www.youtube.com/watch?v=bHwl8TdEI6k", "short/url/2" },
                    { 3, "https://www.youtube.com/watch?v=_2By2ane2I4&t=867s", "short/url/3" }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id", "Author", "Content", "CreationTime", "Description" },
                values: new object[,]
                {
                    { 1, "Test Mike", "This is test content for an important inner report on topic A. There is a place for report details and content.", new DateTime(2021, 10, 1, 1, 41, 50, 329, DateTimeKind.Local).AddTicks(7450), "Important inner report on topic A" },
                    { 2, "Trial John", "This is test content for an important inner report on topic B. There is a place for report details and content.", new DateTime(2021, 10, 1, 1, 41, 50, 336, DateTimeKind.Local).AddTicks(4198), "Important inner report on topic B" },
                    { 3, "Excercise Bob", "This is test content for an important inner report on topic C. There is a place for report details and content.", new DateTime(2021, 10, 1, 1, 41, 50, 336, DateTimeKind.Local).AddTicks(4265), "Important inner report on topic C" }
                });
        }
    }
}
