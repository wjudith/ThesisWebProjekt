using Microsoft.EntityFrameworkCore.Migrations;

namespace ThesisWebProjekt.Migrations
{
    public partial class newnew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Lehrstuehle_LehrstuhlId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Thesis_Lehrstuehle_LehrstuhlId",
                table: "Thesis");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lehrstuehle",
                table: "Lehrstuehle");

            migrationBuilder.RenameTable(
                name: "Lehrstuehle",
                newName: "Lehrstuhl");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lehrstuhl",
                table: "Lehrstuhl",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Lehrstuhl_LehrstuhlId",
                table: "AspNetUsers",
                column: "LehrstuhlId",
                principalTable: "Lehrstuhl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Thesis_Lehrstuhl_LehrstuhlId",
                table: "Thesis",
                column: "LehrstuhlId",
                principalTable: "Lehrstuhl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Lehrstuhl_LehrstuhlId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Thesis_Lehrstuhl_LehrstuhlId",
                table: "Thesis");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lehrstuhl",
                table: "Lehrstuhl");

            migrationBuilder.RenameTable(
                name: "Lehrstuhl",
                newName: "Lehrstuehle");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lehrstuehle",
                table: "Lehrstuehle",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Lehrstuehle_LehrstuhlId",
                table: "AspNetUsers",
                column: "LehrstuhlId",
                principalTable: "Lehrstuehle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Thesis_Lehrstuehle_LehrstuhlId",
                table: "Thesis",
                column: "LehrstuhlId",
                principalTable: "Lehrstuehle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
