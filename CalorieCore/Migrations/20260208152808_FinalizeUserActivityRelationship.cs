using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalorieCore.Migrations
{
    /// <inheritdoc />
    public partial class FinalizeUserActivityRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Activities");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Meals",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "UserAccountId",
                table: "Meals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Activities",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "UserAccountId",
                table: "Activities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Meals_UserAccountId",
                table: "Meals",
                column: "UserAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_UserAccountId",
                table: "Activities",
                column: "UserAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_UserAccounts_UserAccountId",
                table: "Activities",
                column: "UserAccountId",
                principalTable: "UserAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_UserAccounts_UserAccountId",
                table: "Meals",
                column: "UserAccountId",
                principalTable: "UserAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_UserAccounts_UserAccountId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Meals_UserAccounts_UserAccountId",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_Meals_UserAccountId",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_Activities_UserAccountId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "UserAccountId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "UserAccountId",
                table: "Activities");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Meals",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Meals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Activities",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Activities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
