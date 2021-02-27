using Microsoft.EntityFrameworkCore.Migrations;

namespace ThesisWebProjekt.Migrations
{
    public partial class users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ThesisType",
                table: "Thesis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Thesis",
                keyColumn: "Id",
                keyValue: 2,
                column: "ThesisType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Thesis",
                keyColumn: "Id",
                keyValue: 3,
                column: "ThesisType",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThesisType",
                table: "Thesis");
        }
    }
}
