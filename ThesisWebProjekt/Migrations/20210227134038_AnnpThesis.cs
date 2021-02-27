using Microsoft.EntityFrameworkCore.Migrations;

namespace ThesisWebProjekt.Migrations
{
    public partial class AnnpThesis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbo.Theses_dbo.Studiengang_StudiengangId",
                table: "Thesis");

            migrationBuilder.DropIndex(
                name: "IX_Thesis_Studiengang",
                table: "Thesis");

            migrationBuilder.DropColumn(
                name: "Studiengang",
                table: "Thesis");

            migrationBuilder.RenameColumn(
                name: "SupervisorId",
                table: "Thesis",
                newName: "StudiengangId");

            migrationBuilder.CreateIndex(
                name: "IX_Thesis_StudiengangId",
                table: "Thesis",
                column: "StudiengangId");

            migrationBuilder.AddForeignKey(
                name: "FK_Thesis_Studiengang_StudiengangId",
                table: "Thesis",
                column: "StudiengangId",
                principalTable: "Studiengang",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Thesis_Studiengang_StudiengangId",
                table: "Thesis");

            migrationBuilder.DropIndex(
                name: "IX_Thesis_StudiengangId",
                table: "Thesis");

            migrationBuilder.RenameColumn(
                name: "StudiengangId",
                table: "Thesis",
                newName: "SupervisorId");

            migrationBuilder.AddColumn<int>(
                name: "Studiengang",
                table: "Thesis",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Thesis",
                keyColumn: "Id",
                keyValue: 1,
                column: "Studiengang",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Thesis",
                keyColumn: "Id",
                keyValue: 2,
                column: "Studiengang",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Thesis",
                keyColumn: "Id",
                keyValue: 3,
                column: "Studiengang",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Thesis",
                keyColumn: "Id",
                keyValue: 4,
                column: "Studiengang",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Thesis_Studiengang",
                table: "Thesis",
                column: "Studiengang");

            migrationBuilder.AddForeignKey(
                name: "FK_dbo.Theses_dbo.Studiengang_StudiengangId",
                table: "Thesis",
                column: "Studiengang",
                principalTable: "Studiengang",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
