using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CalorieTrackerApp.Migrations
{
    /// <inheritdoc />
    public partial class CompleteGlobalRecipes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Description", "IsGlobal", "IsHealthy" },
                values: new object[] { "Grilled chicken served with brown rice and fresh Mediterranean vegetables.", true, true });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Description", "IsGlobal", "IsHealthy" },
                values: new object[] { "A vegetarian wrap packed with fiber-rich chickpeas and fresh vegetables.", true, true });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Description", "IsGlobal", "IsHealthy" },
                values: new object[] { "High-protein oatmeal topped with berries and almond butter.", true, true });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Description", "Difficulty", "IsGlobal", "IsHealthy" },
                values: new object[] { "Lean turkey patties grilled and seasoned with herbs.", "Medium", true, true });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Description", "IsGlobal", "IsHealthy" },
                values: new object[] { "Low-carb zucchini noodles tossed in fresh basil pesto.", true, true });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Description", "IsGlobal", "IsHealthy" },
                values: new object[] { "Oven-baked cod fillet flavored with lemon zest and fresh herbs.", true, true });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Description", "IsGlobal", "IsHealthy" },
                values: new object[] { "Whole grain toast topped with mashed avocado and a perfectly cooked egg.", true, true });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Description", "Difficulty", "IsGlobal", "IsHealthy" },
                values: new object[] { "Light homemade soup with lean chicken and fresh vegetables.", "Medium", true, true });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Description", "IsGlobal", "IsHealthy" },
                values: new object[] { "Protein-rich cottage cheese topped with fresh fruit.", true, true });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Description", "Difficulty", "IsGlobal", "IsHealthy" },
                values: new object[] { "Lean beef stir fried with colorful vegetables.", "Medium", true, true });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Description", "Instructions", "IsGlobal", "IsHealthy" },
                values: new object[] { "Fluffy omelette filled with spinach and feta cheese.", "1. Whisk eggs. 2. Sauté spinach. 3. Add eggs and feta. 4. Cook until set.", true, true });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Description", "Difficulty", "Instructions", "IsGlobal", "IsHealthy" },
                values: new object[] { "Grilled shrimp served over quinoa with avocado and tomatoes.", "Medium", "1. Grill shrimp. 2. Cook quinoa. 3. Assemble bowl and drizzle lime juice.", true, true });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Description", "Difficulty", "Instructions", "IsGlobal", "IsHealthy" },
                values: new object[] { "Bell peppers stuffed with lean turkey and brown rice.", "Medium", "1. Cook turkey with spinach. 2. Mix with rice. 3. Stuff peppers and bake 25 minutes.", true, true });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Description", "Instructions", "IsGlobal", "IsHealthy" },
                values: new object[] { "Fresh salad combining chickpeas and creamy avocado.", "1. Combine ingredients. 2. Toss with lemon and olive oil.", true, true });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Description", "Instructions", "IsGlobal", "IsHealthy" },
                values: new object[] { "Roasted sweet potato topped with garlic yogurt sauce.", "1. Bake sweet potato. 2. Prepare yogurt sauce. 3. Top and serve.", true, true });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Description", "Instructions", "IsGlobal", "IsHealthy" },
                values: new object[] { "Light whole wheat wrap filled with grilled chicken and Caesar-style salad.", "1. Slice grilled chicken. 2. Add to tortilla with lettuce and dressing. 3. Sprinkle parmesan and wrap tightly.", true, true });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Description", "IsGlobal", "IsHealthy" },
                values: new object[] { "Fresh Greek salad topped with seasoned grilled chicken breast.", true, true });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Description", "IsGlobal", "IsHealthy" },
                values: new object[] { "Thick smoothie bowl blended with berries and protein powder.", true, true });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Description", "IsGlobal", "IsHealthy" },
                values: new object[] { "Oven-baked tilapia infused with lemon and garlic flavors.", true, true });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Description", "Difficulty", "IsGlobal", "IsHealthy" },
                values: new object[] { "Plant-based stir fry with tofu and colorful vegetables.", "Medium", true, true });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "Description", "IsGlobal", "IsHealthy" },
                values: new object[] { "Healthy brown rice fried with eggs and vegetables.", true, true });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "Description", "IsGlobal", "IsHealthy" },
                values: new object[] { "Low-carb salad with grilled chicken and creamy avocado.", true, true });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "Description", "IsGlobal", "IsHealthy" },
                values: new object[] { "Whole wheat pasta mixed with tuna and sautéed spinach.", true, true });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "Description", "IsGlobal", "IsHealthy" },
                values: new object[] { "Protein-rich pancakes made with cottage cheese and oats.", true, true });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "Description", "Difficulty", "IsGlobal", "IsHealthy" },
                values: new object[] { "Roasted seasonal vegetables served over quinoa.", "Medium", true, true });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "Description", "Instructions", "IsGlobal" },
                values: new object[] { "Crispy whole wheat quesadilla filled with chicken and avocado.", "1. Fill tortilla with chicken, avocado and cheese. 2. Cook in pan until crispy on both sides.", true });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "Description", "Instructions", "IsGlobal", "IsHealthy" },
                values: new object[] { "Healthy baked oatmeal cut into portable squares.", "1. Mix ingredients. 2. Pour into baking dish. 3. Bake 25 minutes at 180°C and slice.", true, true });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "Description", "IsGlobal", "IsHealthy" },
                values: new object[] { "Soft tacos filled with grilled chicken and fresh vegetables.", true, true });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "Description", "Difficulty", "IsGlobal", "IsHealthy" },
                values: new object[] { "Hearty vegetarian curry with red lentils and spinach.", "Medium", true, true });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "Description", "Instructions", "IsGlobal", "IsHealthy" },
                values: new object[] { "Greek yogurt bowl with apple slices, cinnamon and honey.", "1. Add yogurt to bowl. 2. Top with apple and walnuts. 3. Sprinkle cinnamon and drizzle honey.", true, true });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Calories", "Description", "Difficulty", "Img", "Ingredients", "Instructions", "IsFavorite", "IsGlobal", "IsHealthy", "Tags", "Title", "Type", "UserAccountId" },
                values: new object[,]
                {
                    { 1, 350, "Fresh mixed greens topped with grilled chicken breast and light vinaigrette.", "Easy", "", "Chicken breast, Mixed greens, Cherry tomatoes, Cucumber, Olive oil, Lemon juice", "1. Grill chicken and slice. 2. Chop vegetables. 3. Toss with olive oil and lemon dressing.", false, true, true, "High-protein, Low-carb, Light", "Grilled Chicken Salad", "Salad", null },
                    { 2, 280, "Classic oatmeal topped with fresh berries and honey.", "Easy", "", "Oats, Milk, Blueberries, Strawberries, Honey", "1. Cook oats with milk. 2. Top with berries. 3. Drizzle honey.", false, true, true, "High-fiber, Quick, Healthy", "Oatmeal with Berries", "Breakfast", null },
                    { 3, 400, "Nutritious quinoa bowl with roasted vegetables.", "Medium", "", "Quinoa, Zucchini, Bell peppers, Carrots, Olive oil", "1. Cook quinoa. 2. Roast vegetables. 3. Combine and drizzle olive oil.", false, true, true, "Vegetarian, High-fiber, Balanced", "Quinoa Vegetable Bowl", "Main", null },
                    { 4, 300, "Layered Greek yogurt with granola and fresh fruit.", "Easy", "", "Greek yogurt, Granola, Mixed berries, Honey", "1. Layer yogurt and granola. 2. Add berries. 3. Drizzle honey.", false, true, true, "High-protein, Quick, Healthy", "Greek Yogurt Parfait", "Snack", null },
                    { 5, 450, "Oven-baked salmon served with roasted asparagus.", "Medium", "", "Salmon fillet, Asparagus, Olive oil, Lemon, Garlic", "1. Season salmon. 2. Bake at 200°C for 15 minutes. 3. Roast asparagus alongside.", false, true, true, "High-protein, Omega-3, Low-carb", "Baked Salmon with Asparagus", "Main", null },
                    { 6, 420, "Quick stir fry with chicken and colorful vegetables.", "Medium", "", "Chicken breast, Broccoli, Carrots, Bell peppers, Soy sauce", "1. Cook chicken strips. 2. Add vegetables. 3. Stir in soy sauce and cook until tender.", false, true, true, "High-protein, Quick, Balanced", "Chicken Stir Fry", "Main", null },
                    { 7, 380, "Whole grain sandwich with turkey and fresh avocado.", "Easy", "", "Whole grain bread, Turkey slices, Avocado, Lettuce, Tomato", "1. Toast bread. 2. Add turkey and sliced avocado. 3. Top with lettuce and tomato.", false, true, true, "High-protein, Quick, Balanced", "Turkey Avocado Sandwich", "Lunch", null },
                    { 8, 290, "Egg omelette filled with fresh vegetables.", "Easy", "", "Eggs, Spinach, Mushrooms, Bell peppers, Olive oil", "1. Whisk eggs. 2. Sauté vegetables. 3. Pour eggs over vegetables and cook until set.", false, true, true, "Low-carb, High-protein, Quick", "Veggie Omelette", "Breakfast", null },
                    { 9, 330, "Hearty lentil soup packed with fiber and nutrients.", "Medium", "", "Red lentils, Onion, Carrots, Garlic, Vegetable broth", "1. Sauté onion and garlic. 2. Add lentils and broth. 3. Simmer 25 minutes.", false, true, true, "Vegetarian, High-fiber, Meal prep", "Lentil Soup", "Soup", null },
                    { 10, 320, "Simple Italian salad with mozzarella and tomatoes.", "Easy", "", "Mozzarella, Tomatoes, Fresh basil, Olive oil, Balsamic glaze", "1. Slice mozzarella and tomatoes. 2. Layer with basil. 3. Drizzle olive oil and balsamic.", false, true, true, "Vegetarian, Fresh, Light", "Caprese Salad", "Salad", null },
                    { 11, 350, "Creamy smoothie with banana and peanut butter.", "Easy", "", "Banana, Peanut butter, Milk, Ice", "1. Add all ingredients to blender. 2. Blend until smooth.", false, true, true, "Energy boost, Quick, Protein", "Peanut Butter Banana Smoothie", "Breakfast", null }
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

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Description", "IsGlobal", "IsHealthy" },
                values: new object[] { "", false, false });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Description", "IsGlobal", "IsHealthy" },
                values: new object[] { "", false, false });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Description", "IsGlobal", "IsHealthy" },
                values: new object[] { "", false, false });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Description", "Difficulty", "IsGlobal", "IsHealthy" },
                values: new object[] { "", "Easy", false, false });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Description", "IsGlobal", "IsHealthy" },
                values: new object[] { "", false, false });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Description", "IsGlobal", "IsHealthy" },
                values: new object[] { "", false, false });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Description", "IsGlobal", "IsHealthy" },
                values: new object[] { "", false, false });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Description", "Difficulty", "IsGlobal", "IsHealthy" },
                values: new object[] { "", "Easy", false, false });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Description", "IsGlobal", "IsHealthy" },
                values: new object[] { "", false, false });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Description", "Difficulty", "IsGlobal", "IsHealthy" },
                values: new object[] { "", "Easy", false, false });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Description", "Instructions", "IsGlobal", "IsHealthy" },
                values: new object[] { "", "1. Whisk eggs with salt and pepper. 2. Sauté spinach in olive oil. 3. Pour eggs over spinach. 4. Add feta and cook until set.", false, false });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Description", "Difficulty", "Instructions", "IsGlobal", "IsHealthy" },
                values: new object[] { "", "Easy", "1. Grill seasoned shrimp 2-3 minutes per side. 2. Cook quinoa. 3. Assemble bowl with vegetables and drizzle lime juice.", false, false });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Description", "Difficulty", "Instructions", "IsGlobal", "IsHealthy" },
                values: new object[] { "", "Easy", "1. Cook turkey with garlic and spinach. 2. Mix with cooked rice. 3. Stuff peppers and bake 25 minutes at 190°C.", false, false });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Description", "Instructions", "IsGlobal", "IsHealthy" },
                values: new object[] { "", "1. Mash chickpeas lightly. 2. Dice avocado and onion. 3. Mix with lemon juice and olive oil.", false, false });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Description", "Instructions", "IsGlobal", "IsHealthy" },
                values: new object[] { "", "1. Bake sweet potato 40 minutes at 200°C. 2. Mix yogurt with garlic and paprika. 3. Top potato with sauce.", false, false });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Description", "Instructions", "IsGlobal", "IsHealthy" },
                values: new object[] { "", "1. Slice grilled chicken. 2. Add to tortilla with lettuce and dressing. 3. Sprinkle parmesan and wrap.", false, false });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Description", "IsGlobal", "IsHealthy" },
                values: new object[] { "", false, false });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Description", "IsGlobal", "IsHealthy" },
                values: new object[] { "", false, false });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Description", "IsGlobal", "IsHealthy" },
                values: new object[] { "", false, false });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Description", "Difficulty", "IsGlobal", "IsHealthy" },
                values: new object[] { "", "Easy", false, false });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "Description", "IsGlobal", "IsHealthy" },
                values: new object[] { "", false, false });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "Description", "IsGlobal", "IsHealthy" },
                values: new object[] { "", false, false });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "Description", "IsGlobal", "IsHealthy" },
                values: new object[] { "", false, false });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "Description", "IsGlobal", "IsHealthy" },
                values: new object[] { "", false, false });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "Description", "Difficulty", "IsGlobal", "IsHealthy" },
                values: new object[] { "", "Easy", false, false });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "Description", "Instructions", "IsGlobal" },
                values: new object[] { "", "1. Fill tortilla with chicken, avocado and cheese. 2. Cook in pan until crispy both sides.", false });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "Description", "Instructions", "IsGlobal", "IsHealthy" },
                values: new object[] { "", "1. Mix all ingredients. 2. Pour into baking dish. 3. Bake 25 minutes at 180°C and slice.", false, false });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "Description", "IsGlobal", "IsHealthy" },
                values: new object[] { "", false, false });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "Description", "Difficulty", "IsGlobal", "IsHealthy" },
                values: new object[] { "", "Easy", false, false });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "Description", "Instructions", "IsGlobal", "IsHealthy" },
                values: new object[] { "", "1. Slice apple. 2. Add to yogurt. 3. Sprinkle cinnamon and walnuts. 4. Drizzle honey.", false, false });
        }
    }
}
