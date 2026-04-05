using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalorieCore.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMacroGoals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ActivityLevel",
                table: "UserAccounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "ActivityMultiplier",
                table: "UserAccounts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "DailyCarbGoal",
                table: "UserAccounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DailyFatGoal",
                table: "UserAccounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DailyProteinGoal",
                table: "UserAccounts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivityLevel",
                table: "UserAccounts");

            migrationBuilder.DropColumn(
                name: "ActivityMultiplier",
                table: "UserAccounts");

            migrationBuilder.DropColumn(
                name: "DailyCarbGoal",
                table: "UserAccounts");

            migrationBuilder.DropColumn(
                name: "DailyFatGoal",
                table: "UserAccounts");

            migrationBuilder.DropColumn(
                name: "DailyProteinGoal",
                table: "UserAccounts");
        }
    }
}
