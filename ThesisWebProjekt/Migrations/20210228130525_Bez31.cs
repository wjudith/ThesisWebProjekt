using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ThesisWebProjekt.Migrations
{
    public partial class Bez31 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Thesis_Lehrstuehle_LehrstuhlId",
                table: "Thesis");

            migrationBuilder.DeleteData(
                table: "Thesis",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Thesis",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Thesis",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Thesis",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AlterColumn<int>(
                name: "LehrstuhlId",
                table: "Thesis",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Thesis_Lehrstuehle_LehrstuhlId",
                table: "Thesis",
                column: "LehrstuhlId",
                principalTable: "Lehrstuehle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Thesis_Lehrstuehle_LehrstuhlId",
                table: "Thesis");

            migrationBuilder.AlterColumn<int>(
                name: "LehrstuhlId",
                table: "Thesis",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Thesis",
                columns: new[] { "Id", "Bachelor", "BetreuerId", "ContentVal", "ContentWt", "Description", "DifficultyVal", "DifficultyWt", "Evaluation", "Filing", "Grade", "LastModified", "LayoutVal", "LayoutWt", "LehrstuhlId", "LiteratureVal", "LiteratureWt", "Master", "NoveltyVal", "NoveltyWt", "Registration", "RichnessVal", "RichnessWt", "Status", "Strengths", "StructureVal", "StructureWt", "StudentEmail", "StudentId", "StudentName", "StudiengangId", "StyleVal", "StyleWt", "Summary", "Title", "Type", "Weaknesses" },
                values: new object[,]
                {
                    { 1, true, null, null, 30, "...", null, 5, null, null, 1.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 15, null, null, 10, false, null, 10, null, null, 10, 0, null, null, 10, "judithw@studmail.de", "2845776", "Judith", null, null, 10, null, "Bachelorthema 1", null, null },
                    { 2, true, null, null, 30, "...", null, 5, null, null, 4.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 15, null, null, 10, false, null, 10, null, null, 10, 3, null, null, 10, "jürgen@studmail.de", "2343546", "Jürgen", null, null, 10, null, "Bachelorthema 2", null, null },
                    { 3, false, null, null, 30, "...", null, 5, null, null, 5.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 15, null, null, 10, true, null, 10, null, null, 10, 0, null, null, 10, "helga@studmail.de", "2785476", "Helga", null, null, 10, null, "Masterthema 1", null, null },
                    { 4, false, null, null, 30, "...", null, 5, null, null, 2.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 15, null, null, 10, true, null, 10, null, null, 10, 0, null, null, 10, "jannisbrzk@studmail.de", "2345676", "Jannis", null, null, 10, null, "Masterthema 2", null, null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Thesis_Lehrstuehle_LehrstuhlId",
                table: "Thesis",
                column: "LehrstuhlId",
                principalTable: "Lehrstuehle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
