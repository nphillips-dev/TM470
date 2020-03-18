using Microsoft.EntityFrameworkCore.Migrations;

namespace TM470.Migrations
{
    public partial class User_bookVersion_friendID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "bookVersion",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "friendId",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bookVersion",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "friendId",
                table: "AspNetUsers");
        }
    }
}
