using Microsoft.EntityFrameworkCore.Migrations;

namespace TM.API.Migrations
{
    public partial class ChangedIdRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Customers_CustomerId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeInputs_Projects_ProjectId",
                table: "TimeInputs");

            migrationBuilder.DropIndex(
                name: "IX_TimeInputs_ProjectId",
                table: "TimeInputs");

            migrationBuilder.DropIndex(
                name: "IX_Projects_CustomerId",
                table: "Projects");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TimeInputs_ProjectId",
                table: "TimeInputs",
                column: "ProjectId");

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
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeInputs_Projects_ProjectId",
                table: "TimeInputs",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
