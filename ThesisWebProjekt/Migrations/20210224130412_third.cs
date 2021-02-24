using Microsoft.EntityFrameworkCore.Migrations;

namespace ThesisWebProjekt.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Thesis_AspNetUsers_AppUserId",
                table: "Thesis");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Thesis",
                newName: "BetreuerId");

            migrationBuilder.RenameIndex(
                name: "IX_Thesis_AppUserId",
                table: "Thesis",
                newName: "IX_Thesis_BetreuerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Thesis_AspNetUsers_BetreuerId",
                table: "Thesis",
                column: "BetreuerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Thesis_AspNetUsers_BetreuerId",
                table: "Thesis");

            migrationBuilder.RenameColumn(
                name: "BetreuerId",
                table: "Thesis",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Thesis_BetreuerId",
                table: "Thesis",
                newName: "IX_Thesis_AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Thesis_AspNetUsers_AppUserId",
                table: "Thesis",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
