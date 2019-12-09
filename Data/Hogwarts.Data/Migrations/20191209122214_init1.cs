using Microsoft.EntityFrameworkCore.Migrations;

namespace Hogwarts.Data.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EnglishName",
                table: "tb_teacher",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoleName",
                table: "IdentityUser",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnglishName",
                table: "tb_teacher");

            migrationBuilder.DropColumn(
                name: "RoleName",
                table: "IdentityUser");
        }
    }
}
