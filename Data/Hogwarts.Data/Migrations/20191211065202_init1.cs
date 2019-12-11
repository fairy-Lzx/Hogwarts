using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hogwarts.Data.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "birthday",
                table: "tb_teacher",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "birthday",
                table: "tb_student",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "birthday",
                table: "tb_teacher",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "birthday",
                table: "tb_student",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
