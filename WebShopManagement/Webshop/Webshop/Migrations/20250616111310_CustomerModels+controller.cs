using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webshop.Migrations
{
    /// <inheritdoc />
    public partial class CustomerModelscontroller : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Customers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Customers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Zip",
                table: "Customers",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Zip",
                table: "Customers");
        }
    }
}
