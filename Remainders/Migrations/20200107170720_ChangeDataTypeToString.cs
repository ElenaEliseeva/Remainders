using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Remainders.Migrations
{
    public partial class ChangeDataTypeToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TimeToWork",
                table: "Remainders",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeToWork",
                table: "Remainders",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
