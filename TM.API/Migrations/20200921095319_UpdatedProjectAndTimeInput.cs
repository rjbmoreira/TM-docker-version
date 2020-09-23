using Microsoft.EntityFrameworkCore.Migrations;

namespace TM.API.Migrations
{
    public partial class UpdatedProjectAndTimeInput : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeInputs_Customers_CustomerId",
                table: "TimeInputs");

            migrationBuilder.DropIndex(
                name: "IX_TimeInputs_CustomerId",
                table: "TimeInputs");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "TimeInputs");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Projects",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_CustomerId",
                table: "Projects",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Customers_CustomerId",
                table: "Projects",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Customers_CustomerId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_CustomerId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Projects");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "TimeInputs",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimeInputs_CustomerId",
                table: "TimeInputs",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeInputs_Customers_CustomerId",
                table: "TimeInputs",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
