using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReminderApp.Infrastructure.Migrations
{
    public partial class changedatetimetooffset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "SendAt",
                table: "Reminders",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "SendAt",
                table: "Reminders",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");
        }
    }
}
