using Microsoft.EntityFrameworkCore.Migrations;

namespace ThesisWebProjekt.Migrations
{
    public partial class xela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Thesis",
                keyColumn: "Id",
                keyValue: 3,
                column: "Grade",
                value: 3.0);

            migrationBuilder.UpdateData(
                table: "Thesis",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Grade", "SupervisorId" },
                values: new object[] { 1.0, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Thesis",
                keyColumn: "Id",
                keyValue: 3,
                column: "Grade",
                value: null);

            migrationBuilder.UpdateData(
                table: "Thesis",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Grade", "SupervisorId" },
                values: new object[] { null, null });
        }
    }
}
