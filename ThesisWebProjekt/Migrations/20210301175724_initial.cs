using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ThesisWebProjekt.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lehrstuhl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lehrstuhl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Studiengang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studiengang", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LehrstuhlId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Lehrstuhl_LehrstuhlId",
                        column: x => x.LehrstuhlId,
                        principalTable: "Lehrstuhl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Thesis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bachelor = table.Column<bool>(type: "bit", nullable: false),
                    Master = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Registration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Filing = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Strengths = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weaknesses = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Evaluation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentVal = table.Column<int>(type: "int", nullable: true),
                    LayoutVal = table.Column<int>(type: "int", nullable: true),
                    StructureVal = table.Column<int>(type: "int", nullable: true),
                    StyleVal = table.Column<int>(type: "int", nullable: true),
                    LiteratureVal = table.Column<int>(type: "int", nullable: true),
                    DifficultyVal = table.Column<int>(type: "int", nullable: true),
                    NoveltyVal = table.Column<int>(type: "int", nullable: true),
                    RichnessVal = table.Column<int>(type: "int", nullable: true),
                    ContentWt = table.Column<int>(type: "int", nullable: true),
                    LayoutWt = table.Column<int>(type: "int", nullable: true),
                    StructureWt = table.Column<int>(type: "int", nullable: true),
                    StyleWt = table.Column<int>(type: "int", nullable: true),
                    LiteratureWt = table.Column<int>(type: "int", nullable: true),
                    DifficultyWt = table.Column<int>(type: "int", nullable: true),
                    NoveltyWt = table.Column<int>(type: "int", nullable: true),
                    RichnessWt = table.Column<int>(type: "int", nullable: true),
                    Grade = table.Column<double>(type: "float", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudiengangId = table.Column<int>(type: "int", nullable: false),
                    BetreuerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LehrstuhlId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thesis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Thesis_AspNetUsers_BetreuerId",
                        column: x => x.BetreuerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Thesis_Lehrstuhl_LehrstuhlId",
                        column: x => x.LehrstuhlId,
                        principalTable: "Lehrstuhl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Thesis_Studiengang_StudiengangId",
                        column: x => x.StudiengangId,
                        principalTable: "Studiengang",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Lehrstuhl",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 10, "BWL 10" },
                    { 11, "BWL 11" },
                    { 12, "BWL 12" }
                });

            migrationBuilder.InsertData(
                table: "Studiengang",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Bachelor Wirtschaftsinformatik" },
                    { 2, "Bachelor Wirtschaftswissenschaften" },
                    { 3, "Master Wirtschaftswissenschaften" },
                    { 4, "Master Wirtschaftsinformatik" }
                });

            migrationBuilder.InsertData(
                table: "Thesis",
                columns: new[] { "Id", "Bachelor", "BetreuerId", "ContentVal", "ContentWt", "Description", "DifficultyVal", "DifficultyWt", "Evaluation", "Filing", "Grade", "LastModified", "LayoutVal", "LayoutWt", "LehrstuhlId", "LiteratureVal", "LiteratureWt", "Master", "NoveltyVal", "NoveltyWt", "Registration", "RichnessVal", "RichnessWt", "Status", "Strengths", "StructureVal", "StructureWt", "StudentEmail", "StudentId", "StudentName", "StudiengangId", "StyleVal", "StyleWt", "Summary", "Title", "Type", "Weaknesses" },
                values: new object[,]
                {
                    { 1, true, null, null, 30, "...", null, 5, null, new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 15, 10, null, 10, false, null, 10, new DateTime(2020, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, 0, null, null, 10, "judith@studmail.de", "2845776", "Judith", 1, null, 10, null, "Bachelorthema 1", 0, null },
                    { 6, false, null, null, 30, "...", null, 5, null, new DateTime(2021, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 15, 12, null, 10, true, null, 10, new DateTime(2021, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, 4, null, null, 10, "Hanna@studmail.de", "2652148", "Hanna", 1, null, 10, null, "Masterthema 4", 1, null },
                    { 2, true, null, null, 30, "...", null, 5, null, new DateTime(2021, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 15, 10, null, 10, false, null, 10, new DateTime(2020, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, 3, null, null, 10, "jürgen@studmail.de", "2343546", "Jürgen", 2, null, 10, null, "Bachelorthema 2", 0, null },
                    { 3, false, null, null, 30, "...", null, 5, null, new DateTime(2021, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 15, 11, null, 10, true, null, 10, new DateTime(2020, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, 0, null, null, 10, "helga@studmail.de", "2785476", "Helga", 3, null, 10, null, "Masterthema 1", 1, null },
                    { 5, false, null, null, 30, "...", null, 5, null, new DateTime(2021, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 15, 11, null, 10, true, null, 10, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, 2, null, null, 10, "Paul@studmail.de", "5645474", "Paul", 3, null, 10, null, "Masterthema 3", 1, null },
                    { 4, false, null, null, 30, "...", null, 5, null, new DateTime(2021, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 15, 12, null, 10, true, null, 10, new DateTime(2021, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, 1, null, null, 10, "jannis@studmail.de", "2345698", "Jannis", 4, null, 10, null, "Masterthema 2", 1, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_LehrstuhlId",
                table: "AspNetUsers",
                column: "LehrstuhlId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Thesis_BetreuerId",
                table: "Thesis",
                column: "BetreuerId");

            migrationBuilder.CreateIndex(
                name: "IX_Thesis_LehrstuhlId",
                table: "Thesis",
                column: "LehrstuhlId");

            migrationBuilder.CreateIndex(
                name: "IX_Thesis_StudiengangId",
                table: "Thesis",
                column: "StudiengangId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Thesis");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Studiengang");

            migrationBuilder.DropTable(
                name: "Lehrstuhl");
        }
    }
}
