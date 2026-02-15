using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CalorieTrackerApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedRecipesUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Calories", "Description", "Difficulty", "Img", "Ingredients", "Instructions", "IsFavorite", "IsGlobal", "IsHealthy", "Tags", "Title", "Type", "UserAccountId" },
                values: new object[,]
                {
                    { 12, 430, "", "Easy", "", "Chicken breast, Brown rice, Cucumber, Cherry tomatoes, Feta cheese, Olive oil, Lemon juice, Oregano", "1. Grill seasoned chicken breast and slice. 2. Cook brown rice. 3. Chop vegetables. 4. Assemble bowl and drizzle with olive oil and lemon.", false, false, false, "High-protein, Balanced, Meal prep", "Mediterranean Chicken Bowl", "Main", null },
                    { 13, 360, "", "Easy", "", "Whole wheat tortilla, Chickpeas, Paprika, Cumin, Lettuce, Tomato, Greek yogurt", "1. Sauté chickpeas with paprika and cumin. 2. Warm tortilla. 3. Add vegetables and yogurt. 4. Wrap tightly and serve.", false, false, false, "Vegetarian, Quick, High-fiber", "Spicy Chickpea Wrap", "Main", null },
                    { 14, 340, "", "Easy", "", "Oats, Milk, Protein powder, Blueberries, Almond butter", "1. Cook oats with milk. 2. Stir in protein powder. 3. Top with blueberries and almond butter.", false, false, false, "High-protein, Energy boost, Healthy", "Protein Oat Breakfast Bowl", "Breakfast", null },
                    { 15, 390, "", "Easy", "", "Lean ground turkey, Garlic, Onion, Parsley, Salt, Pepper", "1. Mix turkey with seasonings. 2. Form patties. 3. Grill 5-6 minutes per side until fully cooked.", false, false, false, "High-protein, Low-fat, Dinner", "Grilled Turkey Patties", "Main", null },
                    { 16, 310, "", "Easy", "", "Zucchini, Basil pesto, Cherry tomatoes, Parmesan", "1. Spiralize zucchini. 2. Lightly sauté for 2-3 minutes. 3. Stir in pesto and top with tomatoes and parmesan.", false, false, false, "Low-carb, Vegetarian, Light", "Zucchini Noodles with Pesto", "Main", null },
                    { 17, 350, "", "Easy", "", "Cod fillet, Olive oil, Lemon zest, Garlic, Parsley, Salt, Pepper", "1. Preheat oven to 200°C. 2. Season cod with herbs and lemon. 3. Bake 12-15 minutes until flaky.", false, false, false, "High-protein, Low-fat, Omega-3", "Baked Cod with Lemon Herbs", "Main", null },
                    { 18, 290, "", "Easy", "", "Whole grain bread, Avocado, Egg, Chili flakes, Salt", "1. Toast bread. 2. Mash avocado on top. 3. Add fried or poached egg. 4. Sprinkle chili flakes.", false, false, false, "Quick, Balanced, Healthy fats", "Avocado Egg Toast", "Breakfast", null },
                    { 19, 280, "", "Easy", "", "Chicken breast, Carrots, Celery, Onion, Garlic, Chicken broth", "1. Sauté vegetables. 2. Add diced chicken and broth. 3. Simmer 20 minutes until chicken is cooked.", false, false, false, "Light, High-protein, Meal prep", "Chicken and Vegetable Soup", "Soup", null },
                    { 20, 260, "", "Easy", "", "Cottage cheese, Pineapple, Strawberries, Chia seeds", "1. Add cottage cheese to bowl. 2. Top with fruit and chia seeds.", false, false, false, "High-protein, Quick, Healthy", "Cottage Cheese Fruit Bowl", "Snack", null },
                    { 21, 440, "", "Easy", "", "Lean beef strips, Bell peppers, Broccoli, Soy sauce, Garlic, Olive oil", "1. Cook beef strips in olive oil. 2. Add vegetables and stir fry 5 minutes. 3. Add soy sauce and cook 2 more minutes.", false, false, false, "High-protein, Dinner, Balanced", "Healthy Beef Stir Fry", "Main", null },
                    { 22, 310, "", "Easy", "", "Eggs, Fresh spinach, Feta cheese, Olive oil, Salt, Pepper", "1. Whisk eggs with salt and pepper. 2. Sauté spinach in olive oil. 3. Pour eggs over spinach. 4. Add feta and cook until set.", false, false, false, "High-protein, Low-carb, Quick", "Spinach and Feta Omelette", "Breakfast", null },
                    { 23, 420, "", "Easy", "", "Shrimp, Quinoa, Avocado, Cherry tomatoes, Lime juice, Olive oil", "1. Grill seasoned shrimp 2-3 minutes per side. 2. Cook quinoa. 3. Assemble bowl with vegetables and drizzle lime juice.", false, false, false, "High-protein, Omega-3, Balanced", "Grilled Shrimp Quinoa Bowl", "Main", null },
                    { 24, 400, "", "Easy", "", "Bell peppers, Lean ground turkey, Spinach, Brown rice, Garlic, Tomato sauce", "1. Cook turkey with garlic and spinach. 2. Mix with cooked rice. 3. Stuff peppers and bake 25 minutes at 190°C.", false, false, false, "High-protein, Meal prep, Healthy", "Turkey and Spinach Stuffed Peppers", "Main", null },
                    { 25, 330, "", "Easy", "", "Chickpeas, Avocado, Red onion, Lemon juice, Olive oil, Parsley", "1. Mash chickpeas lightly. 2. Dice avocado and onion. 3. Mix with lemon juice and olive oil.", false, false, false, "Vegetarian, High-fiber, Light", "Avocado Chickpea Salad", "Salad", null },
                    { 26, 360, "", "Easy", "", "Sweet potato, Greek yogurt, Garlic, Paprika, Olive oil", "1. Bake sweet potato 40 minutes at 200°C. 2. Mix yogurt with garlic and paprika. 3. Top potato with sauce.", false, false, false, "Vegetarian, High-fiber, Comfort food", "Baked Sweet Potato with Yogurt Sauce", "Main", null },
                    { 27, 390, "", "Easy", "", "Grilled chicken, Whole wheat tortilla, Romaine lettuce, Light Caesar dressing, Parmesan", "1. Slice grilled chicken. 2. Add to tortilla with lettuce and dressing. 3. Sprinkle parmesan and wrap.", false, false, false, "High-protein, Quick, Lunch", "Chicken Caesar Wrap Light", "Main", null },
                    { 28, 410, "", "Easy", "", "Chicken breast, Cucumber, Tomato, Olives, Feta, Olive oil, Oregano", "1. Grill chicken and slice. 2. Chop vegetables. 3. Toss with olive oil and oregano. 4. Top with feta.", false, false, false, "High-protein, Mediterranean, Balanced", "Greek Salad with Grilled Chicken", "Salad", null },
                    { 29, 300, "", "Easy", "", "Banana, Frozen berries, Protein powder, Almond milk, Chia seeds", "1. Blend banana, berries, protein powder and milk. 2. Pour into bowl. 3. Top with chia seeds.", false, false, false, "High-protein, Energy boost, Healthy", "Protein Smoothie Bowl", "Breakfast", null },
                    { 30, 340, "", "Easy", "", "Tilapia fillet, Lemon juice, Garlic, Olive oil, Parsley, Salt", "1. Season tilapia with garlic and lemon. 2. Bake 12-15 minutes at 200°C. 3. Garnish with parsley.", false, false, false, "Low-fat, High-protein, Dinner", "Lemon Garlic Tilapia", "Main", null },
                    { 31, 370, "", "Easy", "", "Firm tofu, Broccoli, Carrots, Bell peppers, Soy sauce, Sesame oil", "1. Cook tofu cubes until golden. 2. Add vegetables and stir fry 5 minutes. 3. Add soy sauce and sesame oil.", false, false, false, "Vegetarian, High-protein, Balanced", "Vegetable Stir Fry with Tofu", "Main", null },
                    { 32, 390, "", "Easy", "", "Brown rice, Eggs, Green peas, Carrots, Soy sauce, Green onion", "1. Scramble eggs in pan. 2. Add cooked rice and vegetables. 3. Stir in soy sauce and green onions.", false, false, false, "Balanced, Quick, Comfort food", "Egg Fried Brown Rice", "Main", null },
                    { 33, 420, "", "Easy", "", "Chicken breast, Avocado, Mixed greens, Cherry tomatoes, Olive oil, Lemon", "1. Grill chicken and slice. 2. Combine with greens and vegetables. 3. Drizzle olive oil and lemon.", false, false, false, "High-protein, Low-carb, Healthy fats", "Grilled Chicken Avocado Salad", "Salad", null },
                    { 34, 430, "", "Easy", "", "Whole wheat pasta, Canned tuna, Spinach, Olive oil, Garlic", "1. Cook pasta. 2. Sauté garlic and spinach. 3. Mix with tuna and pasta.", false, false, false, "High-protein, Balanced, Quick", "Healthy Tuna Pasta", "Main", null },
                    { 35, 310, "", "Easy", "", "Cottage cheese, Eggs, Oats, Baking powder", "1. Blend all ingredients. 2. Cook small pancakes on medium heat 2-3 minutes per side.", false, false, false, "High-protein, Healthy, Quick", "Cottage Cheese Pancakes", "Breakfast", null },
                    { 36, 380, "", "Easy", "", "Zucchini, Eggplant, Bell peppers, Olive oil, Quinoa", "1. Roast chopped vegetables 25 minutes at 200°C. 2. Serve over cooked quinoa.", false, false, false, "Vegetarian, High-fiber, Balanced", "Roasted Vegetable Bowl", "Main", null },
                    { 37, 450, "", "Easy", "", "Whole wheat tortilla, Grilled chicken, Avocado, Light cheese", "1. Fill tortilla with chicken, avocado and cheese. 2. Cook in pan until crispy both sides.", false, false, false, "High-protein, Quick, Comfort food", "Chicken and Avocado Quesadilla", "Main", null },
                    { 38, 290, "", "Easy", "", "Oats, Milk, Eggs, Honey, Blueberries", "1. Mix all ingredients. 2. Pour into baking dish. 3. Bake 25 minutes at 180°C and slice.", false, false, false, "High-fiber, Meal prep, Breakfast", "Baked Oatmeal Squares", "Snack", null },
                    { 39, 410, "", "Easy", "", "Chicken breast, Corn tortillas, Lettuce, Tomato, Greek yogurt", "1. Grill chicken and slice. 2. Fill tortillas with chicken and vegetables. 3. Top with yogurt.", false, false, false, "High-protein, Quick, Dinner", "Grilled Chicken Tacos", "Main", null },
                    { 40, 420, "", "Easy", "", "Red lentils, Spinach, Onion, Garlic, Coconut milk, Curry powder", "1. Cook onion and garlic. 2. Add lentils, coconut milk and curry powder. 3. Simmer 20 minutes. 4. Stir in spinach.", false, false, false, "Vegetarian, High-fiber, Meal prep", "Lentil and Spinach Curry", "Main", null },
                    { 41, 270, "", "Easy", "", "Greek yogurt, Apple, Cinnamon, Honey, Walnuts", "1. Slice apple. 2. Add to yogurt. 3. Sprinkle cinnamon and walnuts. 4. Drizzle honey.", false, false, false, "Quick, Healthy, Light", "Apple Cinnamon Yogurt Bowl", "Snack", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Calories", "Description", "Difficulty", "Img", "Ingredients", "Instructions", "IsFavorite", "IsGlobal", "IsHealthy", "Tags", "Title", "Type", "UserAccountId" },
                values: new object[,]
                {
                    { 1, 350, "", "Easy", "/images/caesar_salad.png", "Romaine lettuce, Parmesan, Croutons, Caesar dressing", "1. Chop lettuce. 2. Add dressing and croutons. 3. Sprinkle parmesan and serve.", false, false, false, "Easy to make, Quick, Low-calorie", "Caesar Salad", "Salad", null },
                    { 2, 550, "", "Easy", "/images/chocolate_cake.png", "Flour, Sugar, Cocoa powder, Eggs, Butter", "1. Mix ingredients. 2. Bake at 180°C for 30 mins. 3. Cool and serve.", false, false, false, "Sweet, High-calorie, Easy to make", "Chocolate Cake", "Dessert", null }
                });
        }
    }
}
