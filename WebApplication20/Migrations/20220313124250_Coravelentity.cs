using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sahra.jobManager.Migrations
{
    public partial class Coravelentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Coravel");

            migrationBuilder.EnsureSchema(
                name: "coravel");

            migrationBuilder.CreateTable(
                name: "JobHistories",
                schema: "Coravel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TypeFullPath = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Failed = table.Column<bool>(type: "bit", nullable: false),
                    ErrorMessage = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    StackTrace = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobHistories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ScheduledJobHistories",
                schema: "Coravel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EndedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TypeFullPath = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Failed = table.Column<bool>(type: "bit", nullable: true),
                    ErrorMessage = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    StackTrace = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduledJobHistories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScheduledJobs",
                schema: "coravel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvocableFullPath = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    CronExpression = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Frequency = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    Days = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    PreventOverlapping = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    TimeZoneInfo = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduledJobs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobHistories",
                schema: "Coravel");

            migrationBuilder.DropTable(
                name: "ScheduledJobHistories",
                schema: "Coravel");

            migrationBuilder.DropTable(
                name: "ScheduledJobs",
                schema: "coravel");
        }
    }
}
