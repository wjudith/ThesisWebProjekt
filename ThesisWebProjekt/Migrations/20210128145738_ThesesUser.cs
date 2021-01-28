using Microsoft.EntityFrameworkCore.Migrations;

namespace ThesisWebProjekt.Migrations
{
    public partial class ThesesUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Thesis",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Thesis_AppUserId",
                table: "Thesis",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Thesis_AspNetUsers_AppUserId",
                table: "Thesis",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Thesis_AspNetUsers_AppUserId",
                table: "Thesis");

            migrationBuilder.DropIndex(
                name: "IX_Thesis_AppUserId",
                table: "Thesis");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Thesis");
        }
    }
}
