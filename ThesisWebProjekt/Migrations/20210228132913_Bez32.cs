using Microsoft.EntityFrameworkCore.Migrations;

namespace ThesisWebProjekt.Migrations
{
    public partial class Bez32 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Thesis_Studiengang_StudiengangId",
                table: "Thesis");

            migrationBuilder.AlterColumn<int>(
                name: "StudiengangId",
                table: "Thesis",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Thesis_Studiengang_StudiengangId",
                table: "Thesis",
                column: "StudiengangId",
                principalTable: "Studiengang",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Thesis_Studiengang_StudiengangId",
                table: "Thesis");

            migrationBuilder.AlterColumn<int>(
                name: "StudiengangId",
                table: "Thesis",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Thesis_Studiengang_StudiengangId",
                table: "Thesis",
                column: "StudiengangId",
                principalTable: "Studiengang",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
