using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CalorieTrackerApp.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreSeedRecipes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Img" },
                values: new object[] { "Healthy salad with grilled chicken, fresh greens, and light dressing.", "" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Img" },
                values: new object[] { "Whole-grain toast topped with avocado and cherry tomatoes.", "" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Img" },
                values: new object[] { "Classic Italian pasta with creamy sauce and pancetta.", "" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Img" },
                values: new object[] { "Fruit smoothie bowl with granola and berries.", "" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Calories", "Description", "Img", "IsHealthy", "Title" },
                values: new object[,]
                {
                    { 5, 280, "Warm oatmeal topped with banana, berries, and honey.", "", true, "Oatmeal with Fruits" },
                    { 6, 220, "Greek yogurt layered with granola and fresh fruits.", "", true, "Greek Yogurt Parfait" },
                    { 7, 550, "Beef strips stir-fried with vegetables and soy sauce.", "", false, "Beef Stir Fry" },
                    { 8, 320, "Egg omelette with peppers, onions, and mushrooms.", "", true, "Vegetable Omelette" },
                    { 9, 420, "Whole-wheat wrap with grilled chicken and veggies.", "", true, "Chicken Wrap" },
                    { 10, 700, "Classic beef cheeseburger with bun and cheese.", "", false, "Cheeseburger" },
                    { 11, 480, "Grilled salmon served with rice and vegetables.", "", true, "Salmon with Rice" },
                    { 12, 340, "Quinoa mixed with cucumber, tomato, and olive oil.", "", true, "Quinoa Salad" },
                    { 13, 360, "Protein-rich pancakes topped with berries.", "", true, "Protein Pancakes" },
                    { 14, 720, "Pasta with creamy Alfredo sauce and chicken.", "", false, "Chicken Alfredo" },
                    { 15, 310, "Tuna mixed with light mayo and vegetables.", "", true, "Tuna Salad" },
                    { 16, 180, "Light soup with seasonal vegetables.", "", true, "Vegetable Soup" },
                    { 17, 600, "Oven-baked chicken wings with BBQ sauce.", "", false, "BBQ Chicken Wings" },
                    { 18, 520, "Pasta with shrimp, garlic, and olive oil.", "", false, "Shrimp Pasta" },
                    { 19, 200, "Mixed fresh fruits with citrus dressing.", "", true, "Fruit Salad" },
                    { 20, 390, "Oatmeal with dark chocolate and nuts.", "", true, "Dark Chocolate Oats" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Img" },
                values: new object[] { "A healthy and protein-packed salad with grilled chicken, fresh greens, tomatoes, and a light vinaigrette.", "~/images/grilled-chicken.jpg" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Img" },
                values: new object[] { "Whole-grain toast topped with smashed avocado, cherry tomatoes, and a sprinkle of sesame seeds.", "~/images/avocado-toast.jpg" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Img" },
                values: new object[] { "Classic Italian pasta with creamy egg sauce, pancetta, and Parmesan cheese.", "~/images/pasta-carbonara.jpg" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Img" },
                values: new object[] { "A refreshing smoothie bowl with blended fruits, granola, and fresh berries.", "~/images/smoothie-bowl.jpg" });
        }
    }
}
