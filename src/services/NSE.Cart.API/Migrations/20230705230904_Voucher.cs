using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NSE.Cart.API.Migrations
{
    public partial class Voucher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "CustomerCart",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "DiscountType",
                table: "CustomerCart",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountValue",
                table: "CustomerCart",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Percentage",
                table: "CustomerCart",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "UsedVoucher",
                table: "CustomerCart",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "VoucherCode",
                table: "CustomerCart",
                type: "VARCHAR(50)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "CustomerCart");

            migrationBuilder.DropColumn(
                name: "DiscountType",
                table: "CustomerCart");

            migrationBuilder.DropColumn(
                name: "DiscountValue",
                table: "CustomerCart");

            migrationBuilder.DropColumn(
                name: "Percentage",
                table: "CustomerCart");

            migrationBuilder.DropColumn(
                name: "UsedVoucher",
                table: "CustomerCart");

            migrationBuilder.DropColumn(
                name: "VoucherCode",
                table: "CustomerCart");
        }
    }
}
