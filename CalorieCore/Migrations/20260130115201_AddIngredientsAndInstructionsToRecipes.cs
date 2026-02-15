using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CalorieTrackerApp.Migrations
{
    /// <inheritdoc />
    public partial class AddIngredientsAndInstructionsToRecipes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 4);

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

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.AddColumn<string>(
                name: "Ingredients",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Instructions",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Img", "Ingredients", "Instructions", "IsHealthy", "Tags", "Title", "Type" },
                values: new object[] { "", "/images/caesar_salad.png", "Romaine lettuce, Parmesan, Croutons, Caesar dressing", "1. Chop lettuce. 2. Add dressing and croutons. 3. Sprinkle parmesan and serve.", false, "Easy to make, Quick, Low-calorie", "Caesar Salad", "Salad" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Calories", "Description", "Img", "Ingredients", "Instructions", "IsHealthy", "Tags", "Title", "Type" },
                values: new object[] { 550, "", "/images/chocolate_cake.png", "Flour, Sugar, Cocoa powder, Eggs, Butter", "1. Mix ingredients. 2. Bake at 180°C for 30 mins. 3. Cool and serve.", false, "Sweet, High-calorie, Easy to make", "Chocolate Cake", "Dessert" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ingredients",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "Instructions",
                table: "Recipes");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Img", "IsHealthy", "Tags", "Title", "Type" },
                values: new object[] { "Healthy salad with grilled chicken, fresh greens, and light dressing.", "", true, "", "Grilled Chicken Salad", "Main" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Calories", "Description", "Img", "IsHealthy", "Tags", "Title", "Type" },
                values: new object[] { 250, "Whole-grain toast topped with avocado and cherry tomatoes.", "", true, "", "Avocado Toast", "Main" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Calories", "Description", "Img", "IsHealthy", "Tags", "Title", "Type" },
                values: new object[,]
                {
                    { 3, 650, "Classic Italian pasta with creamy sauce and pancetta.", "", false, "", "Pasta Carbonara", "Main" },
                    { 4, 300, "Fruit smoothie bowl with granola and berries.", "", true, "", "Smoothie Bowl", "Main" },
                    { 5, 280, "Warm oatmeal topped with banana, berries, and honey.", "", true, "", "Oatmeal with Fruits", "Main" },
                    { 6, 220, "Greek yogurt layered with granola and fresh fruits.", "", true, "", "Greek Yogurt Parfait", "Main" },
                    { 7, 550, "Beef strips stir-fried with vegetables and soy sauce.", "", false, "", "Beef Stir Fry", "Main" },
                    { 8, 320, "Egg omelette with peppers, onions, and mushrooms.", "", true, "", "Vegetable Omelette", "Main" },
                    { 9, 420, "Whole-wheat wrap with grilled chicken and veggies.", "", true, "", "Chicken Wrap", "Main" },
                    { 10, 700, "Classic beef cheeseburger with bun and cheese.", "", false, "", "Cheeseburger", "Main" },
                    { 11, 480, "Grilled salmon served with rice and vegetables.", "", true, "", "Salmon with Rice", "Main" },
                    { 12, 340, "Quinoa mixed with cucumber, tomato, and olive oil.", "", true, "", "Quinoa Salad", "Main" },
                    { 13, 360, "Protein-rich pancakes topped with berries.", "", true, "", "Protein Pancakes", "Main" },
                    { 14, 720, "Pasta with creamy Alfredo sauce and chicken.", "", false, "", "Chicken Alfredo", "Main" },
                    { 15, 310, "Tuna mixed with light mayo and vegetables.", "", true, "", "Tuna Salad", "Main" },
                    { 16, 180, "Light soup with seasonal vegetables.", "", true, "", "Vegetable Soup", "Main" },
                    { 17, 600, "Oven-baked chicken wings with BBQ sauce.", "", false, "", "BBQ Chicken Wings", "Main" },
                    { 18, 520, "Pasta with shrimp, garlic, and olive oil.", "", false, "", "Shrimp Pasta", "Main" },
                    { 19, 200, "Mixed fresh fruits with citrus dressing.", "", true, "", "Fruit Salad", "Main" },
                    { 20, 390, "Oatmeal with dark chocolate and nuts.", "", true, "", "Dark Chocolate Oats", "Main" },
                    { 21, 260, "Oven-baked sweet potatoes with olive oil and herbs.", "", true, "", "Baked Sweet Potatoes", "Main" }
                });
        }
    }
}
