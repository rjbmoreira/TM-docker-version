using Microsoft.EntityFrameworkCore.Migrations;

namespace TM.API.Migrations
{
    public partial class changingTimeSpent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "TimeSpent",
                table: "TimeInputs",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TimeSpent",
                table: "TimeInputs",
                type: "integer",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
