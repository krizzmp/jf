using Microsoft.EntityFrameworkCore.Migrations;

namespace jf_web.Migrations
{
    public partial class InitialCreate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "Members",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Members",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Magazine",
                table: "Members",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Members",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Company",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Magazine",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Members");
        }
    }
}
