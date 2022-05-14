using Microsoft.EntityFrameworkCore.Migrations;

namespace AboutMeProject.Infrastructure.Migrations
{
    public partial class migMessageUserUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Content",
                table: "MessageUsers",
                newName: "MessageContent");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MessageContent",
                table: "MessageUsers",
                newName: "Content");
        }
    }
}
