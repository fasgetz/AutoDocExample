using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoDoc.DataBase.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "AutoDoc");

            migrationBuilder.CreateTable(
                name: "Statuses",
                schema: "AutoDoc",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                schema: "AutoDoc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaskStatusId = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Task_Statuses_TaskStatusId",
                        column: x => x.TaskStatusId,
                        principalSchema: "AutoDoc",
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "File",
                schema: "AutoDoc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    FileStatusId = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_Statuses_FileStatusId",
                        column: x => x.FileStatusId,
                        principalSchema: "AutoDoc",
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_File_Task_TaskId",
                        column: x => x.TaskId,
                        principalSchema: "AutoDoc",
                        principalTable: "Task",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_File_FileStatusId",
                schema: "AutoDoc",
                table: "File",
                column: "FileStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_File_TaskId",
                schema: "AutoDoc",
                table: "File",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_TaskStatusId",
                schema: "AutoDoc",
                table: "Task",
                column: "TaskStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "File",
                schema: "AutoDoc");

            migrationBuilder.DropTable(
                name: "Task",
                schema: "AutoDoc");

            migrationBuilder.DropTable(
                name: "Statuses",
                schema: "AutoDoc");
        }
    }
}
