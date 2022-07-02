using Microsoft.EntityFrameworkCore.Migrations;

namespace Sahra.jobManager.Migrations
{
    public partial class ChangeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Frequency",
                schema: "coravel",
                table: "ScheduledJobs");

            migrationBuilder.RenameColumn(
                name: "Days",
                schema: "coravel",
                table: "ScheduledJobs",
                newName: "EveryMinute");

            migrationBuilder.AddColumn<string>(
                name: "EveryDayofTheWeek",
                schema: "coravel",
                table: "ScheduledJobs",
                type: "nvarchar(1024)",
                maxLength: 1024,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EveryHour",
                schema: "coravel",
                table: "ScheduledJobs",
                type: "nvarchar(1024)",
                maxLength: 1024,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EverySecond",
                schema: "coravel",
                table: "ScheduledJobs",
                type: "nvarchar(1024)",
                maxLength: 1024,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EveryDayofTheWeek",
                schema: "coravel",
                table: "ScheduledJobs");

            migrationBuilder.DropColumn(
                name: "EveryHour",
                schema: "coravel",
                table: "ScheduledJobs");

            migrationBuilder.DropColumn(
                name: "EverySecond",
                schema: "coravel",
                table: "ScheduledJobs");

            migrationBuilder.RenameColumn(
                name: "EveryMinute",
                schema: "coravel",
                table: "ScheduledJobs",
                newName: "Days");

            migrationBuilder.AddColumn<int>(
                name: "Frequency",
                schema: "coravel",
                table: "ScheduledJobs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
