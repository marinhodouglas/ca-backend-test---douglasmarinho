using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BillingAPI.Migrations
{
    /// <inheritdoc />
    public partial class AlterCustomers2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "Products",
                newName: "Description");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "BillingLines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "BillingLines");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Products",
                newName: "ProductName");
        }
    }
}
