using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InstallmentsSystem.Migrations
{
    public partial class AddNextPayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "NextPayment",
                table: "installments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NextPayment",
                table: "installments");
        }
    }
}
