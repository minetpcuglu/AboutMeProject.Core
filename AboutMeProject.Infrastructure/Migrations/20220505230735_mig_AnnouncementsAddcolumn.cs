using Microsoft.EntityFrameworkCore.Migrations;

namespace AboutMeProject.Infrastructure.Migrations
{
    public partial class mig_AnnouncementsAddcolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Announcements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Value",
                table: "Announcements",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Announcements");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Announcements");
        }
    }
}
