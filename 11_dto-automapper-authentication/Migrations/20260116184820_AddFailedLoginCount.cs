using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _11_dto_automapper_authentication.Migrations
{
    /// <inheritdoc />
    public partial class AddFailedLoginCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FailedLoginCount",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FailedLoginCount",
                table: "Accounts");
        }
    }
}
