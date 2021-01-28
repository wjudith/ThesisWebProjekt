using Microsoft.EntityFrameworkCore.Migrations;

namespace ThesisWebProjekt.Migrations
{
    public partial class Lehrstuhl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LehrstuhlId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Lehrstuehle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lehrstuehle", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_LehrstuhlId",
                table: "AspNetUsers",
                column: "LehrstuhlId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Lehrstuehle_LehrstuhlId",
                table: "AspNetUsers",
                column: "LehrstuhlId",
                principalTable: "Lehrstuehle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Lehrstuehle_LehrstuhlId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Lehrstuehle");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_LehrstuhlId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LehrstuhlId",
                table: "AspNetUsers");
        }
    }
}
