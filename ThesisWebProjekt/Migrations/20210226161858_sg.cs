using Microsoft.EntityFrameworkCore.Migrations;

namespace ThesisWebProjekt.Migrations
{
    public partial class sg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProgrammeId",
                table: "Thesis",
                newName: "Studiengang");

            migrationBuilder.RenameIndex(
                name: "IX_Thesis_ProgrammeId",
                table: "Thesis",
                newName: "IX_Thesis_Studiengang");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Studiengang",
                table: "Thesis",
                newName: "ProgrammeId");

            migrationBuilder.RenameIndex(
                name: "IX_Thesis_Studiengang",
                table: "Thesis",
                newName: "IX_Thesis_ProgrammeId");
        }
    }
}
