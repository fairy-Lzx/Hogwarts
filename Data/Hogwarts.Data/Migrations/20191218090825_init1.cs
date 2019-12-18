using Microsoft.EntityFrameworkCore.Migrations;

namespace Hogwarts.Data.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Tid",
                table: "tb_SC",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tid",
                table: "tb_SC");
        }
    }
}
