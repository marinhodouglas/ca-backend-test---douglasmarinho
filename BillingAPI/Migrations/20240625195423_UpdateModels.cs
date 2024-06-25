using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BillingAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "BillingLines",
                newName: "UnitPrice");

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "Billings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "Billings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "InvoiceNumber",
                table: "Billings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "Billings",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Subtotal",
                table: "BillingLines",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Billings");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "Billings");

            migrationBuilder.DropColumn(
                name: "InvoiceNumber",
                table: "Billings");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "Billings");

            migrationBuilder.DropColumn(
                name: "Subtotal",
                table: "BillingLines");

            migrationBuilder.RenameColumn(
                name: "UnitPrice",
                table: "BillingLines",
                newName: "Price");
        }
    }
}
