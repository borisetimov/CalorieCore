using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalorieTrackerApp.Migrations
{
    /// <inheritdoc />
    public partial class AddSweetPotatoRecipe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Calories", "Description", "Img", "IsHealthy", "Title" },
                values: new object[] { 21, 260, "Oven-baked sweet potatoes with olive oil and herbs.", "", true, "Baked Sweet Potatoes" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 21);
        }
    }
}
