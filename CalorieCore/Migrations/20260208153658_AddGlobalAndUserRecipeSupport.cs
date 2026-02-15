using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalorieTrackerApp.Migrations
{
    /// <inheritdoc />
    public partial class AddGlobalAndUserRecipeSupport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsGlobal",
                table: "Recipes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UserAccountId",
                table: "Recipes",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IsGlobal", "UserAccountId" },
                values: new object[] { false, null });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "IsGlobal", "UserAccountId" },
                values: new object[] { false, null });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_UserAccountId",
                table: "Recipes",
                column: "UserAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_UserAccounts_UserAccountId",
                table: "Recipes",
                column: "UserAccountId",
                principalTable: "UserAccounts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_UserAccounts_UserAccountId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_UserAccountId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "IsGlobal",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "UserAccountId",
                table: "Recipes");
        }
    }
}
