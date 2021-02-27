using Microsoft.EntityFrameworkCore.Migrations;

namespace ThesisWebProjekt.Migrations
{
    public partial class SG2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbo.Theses_dbo.Programmes_ProgrammeId",
                table: "Thesis");

            migrationBuilder.DropTable(
                name: "Programme");

            migrationBuilder.CreateTable(
                name: "Studiengang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studiengang", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_dbo.Theses_dbo.Studiengang_StudiengangId",
                table: "Thesis",
                column: "Studiengang",
                principalTable: "Studiengang",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbo.Theses_dbo.Studiengang_StudiengangId",
                table: "Thesis");

            migrationBuilder.DropTable(
                name: "Studiengang");

            migrationBuilder.CreateTable(
                name: "Programme",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programme", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_dbo.Theses_dbo.Programmes_ProgrammeId",
                table: "Thesis",
                column: "Studiengang",
                principalTable: "Programme",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
