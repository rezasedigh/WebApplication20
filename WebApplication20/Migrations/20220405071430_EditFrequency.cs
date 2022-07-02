using Microsoft.EntityFrameworkCore.Migrations;

namespace Sahra.jobManager.Migrations
{
    public partial class EditFrequency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Frequency",
                schema: "coravel",
                table: "ScheduledJobs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(1024)",
                oldMaxLength: 1024,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Frequency",
                schema: "coravel",
                table: "ScheduledJobs",
                type: "nvarchar(1024)",
                maxLength: 1024,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
