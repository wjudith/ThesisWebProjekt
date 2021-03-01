using Microsoft.EntityFrameworkCore.Migrations;

namespace ThesisWebProjekt.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Thesis",
                keyColumn: "Id",
                keyValue: 2,
                column: "StudiengangId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Thesis",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "LehrstuhlId", "StudiengangId", "Type" },
                values: new object[] { 11, 3, 1 });

            migrationBuilder.UpdateData(
                table: "Thesis",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "LehrstuhlId", "StudiengangId", "Type" },
                values: new object[] { 11, 4, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Thesis",
                keyColumn: "Id",
                keyValue: 2,
                column: "StudiengangId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Thesis",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "LehrstuhlId", "StudiengangId", "Type" },
                values: new object[] { 10, 1, null });

            migrationBuilder.UpdateData(
                table: "Thesis",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "LehrstuhlId", "StudiengangId", "Type" },
                values: new object[] { 10, 1, null });
        }
    }
}
