using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ThesisWebProjekt.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Thesis",
                columns: new[] { "Id", "AppUserId", "Bachelor", "ContentVal", "ContentWt", "Description", "DifficultyVal", "DifficultyWt", "Evaluation", "Filing", "Grade", "LastModified", "LayoutVal", "LayoutWt", "LiteratureVal", "LiteratureWt", "Master", "NoveltyVal", "NoveltyWt", "ProgrammeId", "Registration", "RichnessVal", "RichnessWt", "Status", "Strengths", "StructureVal", "StructureWt", "StudentEmail", "StudentId", "StudentName", "StyleVal", "StyleWt", "Summary", "SupervisorId", "Title", "Type", "Weaknesses" },
                values: new object[] { 4, null, false, null, 30, "...", null, 5, null, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 15, null, 10, true, null, 10, null, null, null, 10, 0, null, null, 10, null, null, "Jannis", null, 10, null, null, "Masterthema 2", null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Thesis",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
