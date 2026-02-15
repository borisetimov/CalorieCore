using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CalorieCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRecipeSeedAndImg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Img",
                table: "Recipes",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Calories", "Description", "Img", "IsHealthy", "Title" },
                values: new object[,]
                {
                    { 1, 350, "A healthy and protein-packed salad with grilled chicken, fresh greens, tomatoes, and a light vinaigrette.", "~/images/grilled-chicken.jpg", true, "Grilled Chicken Salad" },
                    { 2, 250, "Whole-grain toast topped with smashed avocado, cherry tomatoes, and a sprinkle of sesame seeds.", "~/images/avocado-toast.jpg", true, "Avocado Toast" },
                    { 3, 650, "Classic Italian pasta with creamy egg sauce, pancetta, and Parmesan cheese.", "~/images/pasta-carbonara.jpg", false, "Pasta Carbonara" },
                    { 4, 300, "A refreshing smoothie bowl with blended fruits, granola, and fresh berries.", "~/images/smoothie-bowl.jpg", true, "Smoothie Bowl" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Img",
                table: "Recipes");
        }
    }
}
