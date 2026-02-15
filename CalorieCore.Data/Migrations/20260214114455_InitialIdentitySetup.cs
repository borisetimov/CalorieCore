using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalorieCore.Migrations
{
    /// <inheritdoc />
    public partial class InitialIdentitySetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "UserAccounts");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "UserAccounts");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "UserAccounts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccounts_IdentityUserId",
                table: "UserAccounts",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccounts_AspNetUsers_IdentityUserId",
                table: "UserAccounts",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAccounts_AspNetUsers_IdentityUserId",
                table: "UserAccounts");

            migrationBuilder.DropIndex(
                name: "IX_UserAccounts_IdentityUserId",
                table: "UserAccounts");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "UserAccounts");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "UserAccounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "UserAccounts",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }
    }
}
