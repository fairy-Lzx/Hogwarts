using Microsoft.EntityFrameworkCore.Migrations;

namespace Hogwarts.Data.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Area",
                table: "tb_student",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "tb_student",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "tb_student",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnglishName",
                table: "tb_course",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Area",
                table: "tb_student");

            migrationBuilder.DropColumn(
                name: "City",
                table: "tb_student");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "tb_student");

            migrationBuilder.DropColumn(
                name: "EnglishName",
                table: "tb_course");
        }
    }
}
