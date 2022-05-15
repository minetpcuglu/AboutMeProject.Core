using Microsoft.EntityFrameworkCore.Migrations;

namespace AboutMeProject.Infrastructure.Migrations
{
    public partial class migsenderrecename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReceiverName",
                table: "MessageUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderName",
                table: "MessageUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceiverName",
                table: "MessageUsers");

            migrationBuilder.DropColumn(
                name: "SenderName",
                table: "MessageUsers");
        }
    }
}
