using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace BlazorApp.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Diaries",
                columns: table => new
                {
                    DiaryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    UserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diaries", x => x.DiaryID);
                    table.ForeignKey(
                        name: "FK_Diaries_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Todos",
                columns: table => new
                {
                    TodoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    UserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todos", x => x.TodoID);
                    table.ForeignKey(
                        name: "FK_Todos_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Diaries",
                columns: new[] { "DiaryID", "Date", "Description", "Title", "UserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Today i have guests at home", "At Home", null },
                    { 2, new DateTime(2020, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Today i created an blazor project", "At Work", null }
                });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "TodoID", "Date", "Description", "Title", "UserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "List of products that i need to buy ...", "Shopping", null },
                    { 2, new DateTime(2020, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adress here", "Meet friends", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Email", "FirstName", "LastName", "Password" },
                values: new object[] { 1, "samir.jan@gmail.com", "Samir", "Jan", "Samir123" });

            migrationBuilder.CreateIndex(
                name: "IX_Diaries_UserID",
                table: "Diaries",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Todos_UserID",
                table: "Todos",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diaries");

            migrationBuilder.DropTable(
                name: "Todos");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
