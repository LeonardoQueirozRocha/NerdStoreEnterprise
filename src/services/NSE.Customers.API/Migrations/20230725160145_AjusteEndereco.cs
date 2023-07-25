using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NSE.Customers.API.Migrations
{
    public partial class AjusteEndereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PublicArea",
                table: "Addresses",
                newName: "PublicPlace");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PublicPlace",
                table: "Addresses",
                newName: "PublicArea");
        }
    }
}
