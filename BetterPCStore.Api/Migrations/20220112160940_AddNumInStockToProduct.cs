using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BetterPCStore.Api.Migrations
{
    public partial class AddNumInStockToProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumInStock",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumInStock",
                table: "Products");
        }
    }
}
