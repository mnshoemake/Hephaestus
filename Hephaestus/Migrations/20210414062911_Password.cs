using Microsoft.EntityFrameworkCore.Migrations;

namespace Hephaestus.Migrations
{
    public partial class Password : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Heroes_Users_UserId",
                table: "Heroes");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Heroes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Heroes_Users_UserId",
                table: "Heroes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Heroes_Users_UserId",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Heroes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Heroes_Users_UserId",
                table: "Heroes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
