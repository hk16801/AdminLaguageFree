using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccessLog",
                columns: table => new
                {
                    AccessId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PageId = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessLog", x => x.AccessId);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PageId = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommentText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.CommentId);
                });

            migrationBuilder.CreateTable(
                name: "LanguageLog",
                columns: table => new
                {
                    LangLogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PageId = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanguageTarget = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromOrTo = table.Column<bool>(type: "bit", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageLog", x => x.LangLogId);
                });

            migrationBuilder.CreateTable(
                name: "Page",
                columns: table => new
                {
                    PageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Page", x => x.PageId);
                });

            migrationBuilder.CreateTable(
                name: "Rate",
                columns: table => new
                {
                    RateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RateNum = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rate", x => x.RateId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Setting",
                columns: table => new
                {
                    SettingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UiLanguagePreference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslationLanguageFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslationLanguageTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConversationLanguageFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConversationLanguageTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PictureLangTo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setting", x => x.SettingId);
                });

            migrationBuilder.CreateTable(
                name: "TranslationHistory",
                columns: table => new
                {
                    TranslationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PageId = table.Column<int>(type: "int", nullable: false),
                    SourceLanguage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TargetLanguage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatedText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranslationHistory", x => x.TranslationId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    National = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "AccountId", "Password", "RoleId", "Status", "Timestamp", "UserId", "Username" },
                values: new object[,]
                {
                    { 1, "lf123456", "1", 1, new DateTime(2024, 3, 19, 15, 26, 0, 130, DateTimeKind.Local).AddTicks(7855), 1, "LF_adminhuy" },
                    { 2, "lf123456", "1", 1, new DateTime(2024, 3, 19, 15, 26, 0, 131, DateTimeKind.Local).AddTicks(5763), 2, "LF_adminkhanh" },
                    { 3, "lf123456", "1", 1, new DateTime(2024, 3, 19, 15, 26, 0, 131, DateTimeKind.Local).AddTicks(5779), 3, "LF_admintuyen" },
                    { 4, "lf123456", "1", 1, new DateTime(2024, 3, 19, 15, 26, 0, 131, DateTimeKind.Local).AddTicks(5781), 4, "LF_admindao" },
                    { 5, "lf123456", "1", 1, new DateTime(2024, 3, 19, 15, 26, 0, 131, DateTimeKind.Local).AddTicks(5783), 5, "LF_admintai" }
                });

            migrationBuilder.InsertData(
                table: "Page",
                columns: new[] { "PageId", "PageName" },
                values: new object[,]
                {
                    { 18, "Favourite" },
                    { 17, "User Guide" },
                    { 16, "QR Scan" },
                    { 15, "Help" },
                    { 14, "Chat Bot" },
                    { 13, "About Us" },
                    { 12, "Welcome" },
                    { 11, "Profile" },
                    { 10, "Weather Detail" },
                    { 8, "News" },
                    { 7, "Translate Image" },
                    { 6, "Translate Speech" },
                    { 5, "Translate Text" },
                    { 4, "Home" },
                    { 3, "Login Gmail" },
                    { 2, "Login SDT" },
                    { 1, "Intro Screen" },
                    { 9, "Weather" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "DateOfBirth", "Email", "FullName", "Gender", "ImageUser", "National", "Phone", "Timestamp" },
                values: new object[,]
                {
                    { 4, new DateTime(2004, 4, 28, 15, 26, 0, 131, DateTimeKind.Local).AddTicks(9230), "admin4@example.com", "Admin 4", "Female", "4.png", "VietNam", "12345674", new DateTime(2024, 3, 19, 15, 26, 0, 131, DateTimeKind.Local).AddTicks(9232) },
                    { 1, new DateTime(2004, 3, 29, 15, 26, 0, 131, DateTimeKind.Local).AddTicks(7840), "admin1@example.com", "Admin 1", "Male", "1.png", "VietNam", "12345671", new DateTime(2024, 3, 19, 15, 26, 0, 131, DateTimeKind.Local).AddTicks(8550) },
                    { 2, new DateTime(2004, 4, 8, 15, 26, 0, 131, DateTimeKind.Local).AddTicks(9208), "admin2@example.com", "Admin 2", "Female", "2.png", "VietNam", "12345672", new DateTime(2024, 3, 19, 15, 26, 0, 131, DateTimeKind.Local).AddTicks(9224) },
                    { 3, new DateTime(2004, 4, 18, 15, 26, 0, 131, DateTimeKind.Local).AddTicks(9226), "admin3@example.com", "Admin 3", "Male", "3.png", "VietNam", "12345673", new DateTime(2024, 3, 19, 15, 26, 0, 131, DateTimeKind.Local).AddTicks(9228) },
                    { 5, new DateTime(2004, 5, 8, 15, 26, 0, 131, DateTimeKind.Local).AddTicks(9233), "admin5@example.com", "Admin 5", "Male", "5.png", "VietNam", "12345675", new DateTime(2024, 3, 19, 15, 26, 0, 131, DateTimeKind.Local).AddTicks(9235) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessLog");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "LanguageLog");

            migrationBuilder.DropTable(
                name: "Page");

            migrationBuilder.DropTable(
                name: "Rate");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Setting");

            migrationBuilder.DropTable(
                name: "TranslationHistory");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
