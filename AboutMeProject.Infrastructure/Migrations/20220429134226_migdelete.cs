using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AboutMeProject.Infrastructure.Migrations
{
    public partial class migdelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "Testimonials");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Testimonials");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Testimonials");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "SocialMedias");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "SocialMedias");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "SocialMedias");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "Educations");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Educations");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Educations");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Abouts");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Testimonials",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Testimonials",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "SocialMedias",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SocialMedias",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Skills",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Skills",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Services",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Services",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Portfolios",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Portfolios",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Messages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Messages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Features",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Features",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Educations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Educations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Contacts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Contacts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Abouts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Abouts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Testimonials");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Testimonials");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "SocialMedias");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SocialMedias");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Educations");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Educations");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Abouts");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "Testimonials",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Testimonials",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Testimonials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "SocialMedias",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "SocialMedias",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "SocialMedias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "Skills",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Skills",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Skills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "Services",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Services",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "Portfolios",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Portfolios",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Portfolios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "Messages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Messages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "Features",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Features",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Features",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "Educations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Educations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Educations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "Contacts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Contacts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "Abouts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Abouts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Abouts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
