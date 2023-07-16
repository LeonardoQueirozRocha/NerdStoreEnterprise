using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NSE.Cart.API.Migrations
{
    public partial class CartCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_CustomerCart_CartId",
                table: "CartItems");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_CustomerCart_CartId",
                table: "CartItems",
                column: "CartId",
                principalTable: "CustomerCart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_CustomerCart_CartId",
                table: "CartItems");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_CustomerCart_CartId",
                table: "CartItems",
                column: "CartId",
                principalTable: "CustomerCart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
