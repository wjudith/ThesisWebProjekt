using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ThesisWebProjekt.Migrations
{
    public partial class top : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Thesis",
                columns: new[] { "Id", "Bachelor", "BetreuerId", "ContentVal", "ContentWt", "Description", "DifficultyVal", "DifficultyWt", "Evaluation", "Filing", "Grade", "LastModified", "LayoutVal", "LayoutWt", "LehrstuhlId", "LiteratureVal", "LiteratureWt", "Master", "NoveltyVal", "NoveltyWt", "Registration", "RichnessVal", "RichnessWt", "Status", "Strengths", "StructureVal", "StructureWt", "StudentEmail", "StudentId", "StudentName", "StudiengangId", "StyleVal", "StyleWt", "Summary", "Title", "Type", "Weaknesses" },
                values: new object[,]
                {
                    { 1, true, null, null, 30, "...", null, 5, null, null, 1.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 15, 10, null, 10, false, null, 10, null, null, 10, 0, null, null, 10, "judithw@studmail.de", "2845776", "Judith", 1, null, 10, null, "Bachelorthema 1", null, null },
                    { 2, true, null, null, 30, "...", null, 5, null, null, 4.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 15, 10, null, 10, false, null, 10, null, null, 10, 3, null, null, 10, "jürgen@studmail.de", "2343546", "Jürgen", 1, null, 10, null, "Bachelorthema 2", null, null },
                    { 3, false, null, null, 30, "...", null, 5, null, null, 5.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 15, 10, null, 10, true, null, 10, null, null, 10, 0, null, null, 10, "helga@studmail.de", "2785476", "Helga", 1, null, 10, null, "Masterthema 1", null, null },
                    { 4, false, null, null, 30, "...", null, 5, null, null, 2.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 15, 10, null, 10, true, null, 10, null, null, 10, 0, null, null, 10, "jannisbrzk@studmail.de", "2345676", "Jannis", 1, null, 10, null, "Masterthema 2", null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
