using Microsoft.EntityFrameworkCore.Migrations;

namespace GC_MVC_SQL_WIN_MAC.Migrations
{
    public partial class OnSaleBool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOnSale",
                table: "Pants",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOnSale",
                table: "Pants");
        }
    }
}
