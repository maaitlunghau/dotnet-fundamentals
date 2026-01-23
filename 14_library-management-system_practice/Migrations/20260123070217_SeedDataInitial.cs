using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _14_library_management_system_practice.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Availability", "BookId", "ISBN", "Title" },
                values: new object[,]
                {
                    { 1, "Robert C. Martin", "Available", 1001, "9780132350884", "Clean Code" },
                    { 2, "Robert C. Martin", "Available", 1002, "9780134494166", "Clean Architecture" },
                    { 3, "Erich Gamma", "Borrowed", 1003, "9780201633610", "Design Patterns" },
                    { 4, "Martin Fowler", "Available", 1004, "9780201485677", "Refactoring" },
                    { 5, "Andrew Hunt", "Borrowed", 1005, "9780201616224", "The Pragmatic Programmer" },
                    { 6, "Kyle Simpson", "Available", 1006, "9781491904244", "You Don't Know JS" },
                    { 7, "Thomas H. Cormen", "Available", 1007, "9780262033848", "Introduction to Algorithms" },
                    { 8, "Adam Freeman", "Borrowed", 1008, "9781484254394", "ASP.NET Core MVC" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { 1, "admin123", "admin", "admin" },
                    { 2, "guest123", "guest", "guest1" },
                    { 3, "guest123", "guest", "guest2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);
        }
    }
}
