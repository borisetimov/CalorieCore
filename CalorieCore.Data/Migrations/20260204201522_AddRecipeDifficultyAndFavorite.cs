using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalorieCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRecipeDifficultyAndFavorite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Difficulty",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsFavorite",
                table: "Recipes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Difficulty", "IsFavorite" },
                values: new object[] { "Easy", false });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Difficulty", "IsFavorite" },
                values: new object[] { "Easy", false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Difficulty",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "IsFavorite",
                table: "Recipes");
        }
    }
}
