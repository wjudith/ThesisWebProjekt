using Microsoft.EntityFrameworkCore.Migrations;

namespace ThesisWebProjekt.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Thesis_AspNetUsers_AppUserId",
                table: "Thesis");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Thesis",
                newName: "BetreuerId");

            migrationBuilder.RenameIndex(
                name: "IX_Thesis_AppUserId",
                table: "Thesis",
                newName: "IX_Thesis_BetreuerId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.InsertData(
                table: "Lehrstuehle",
                columns: new[] { "Id", "Name" },
                values: new object[] { 10, "BWL 10" });

            migrationBuilder.InsertData(
                table: "Lehrstuehle",
                columns: new[] { "Id", "Name" },
                values: new object[] { 11, "BWL 11" });

            migrationBuilder.InsertData(
                table: "Lehrstuehle",
                columns: new[] { "Id", "Name" },
                values: new object[] { 12, "BWL 12" });

            migrationBuilder.AddForeignKey(
                name: "FK_Thesis_AspNetUsers_BetreuerId",
                table: "Thesis",
                column: "BetreuerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Thesis_AspNetUsers_BetreuerId",
                table: "Thesis");

            migrationBuilder.DeleteData(
                table: "Lehrstuehle",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Lehrstuehle",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Lehrstuehle",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.RenameColumn(
                name: "BetreuerId",
                table: "Thesis",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Thesis_BetreuerId",
                table: "Thesis",
                newName: "IX_Thesis_AppUserId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Thesis_AspNetUsers_AppUserId",
                table: "Thesis",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
