using Microsoft.EntityFrameworkCore.Migrations;

namespace InstallmentsSystem.Migrations
{
    public partial class AddingRemainingtoInstallments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Remaining",
                table: "installments",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Remaining",
                table: "installments");
        }
    }
}
