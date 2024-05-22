using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment3.Migrations
{
    /// <inheritdoc />
    public partial class ReservSetupUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Time",
                table: "Reservations",
                type: "time(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Time",
                table: "Reservations",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time(6)");
        }
    }
}
