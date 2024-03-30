using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace project_cource.Migrations
{
    public partial class CategoryId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "price",
                table: "Items",
                newName: "Price");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Items",
                newName: "price");
        }
    }
}
