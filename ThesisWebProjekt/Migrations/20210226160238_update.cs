using Microsoft.EntityFrameworkCore.Migrations;

namespace ThesisWebProjekt.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Grade",
                table: "Thesis",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "Thesis",
                keyColumn: "Id",
                keyValue: 1,
                column: "Grade",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "Thesis",
                keyColumn: "Id",
                keyValue: 2,
                column: "Grade",
                value: 0.0);

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
                column: "Grade",
                value: 1.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Grade",
                table: "Thesis",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "Thesis",
                keyColumn: "Id",
                keyValue: 1,
                column: "Grade",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Thesis",
                keyColumn: "Id",
                keyValue: 2,
                column: "Grade",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Thesis",
                keyColumn: "Id",
                keyValue: 3,
                column: "Grade",
                value: 3m);

            migrationBuilder.UpdateData(
                table: "Thesis",
                keyColumn: "Id",
                keyValue: 4,
                column: "Grade",
                value: 1m);
        }
    }
}
