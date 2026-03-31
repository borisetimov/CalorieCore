using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CalorieCore.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class TotalResetWithIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false),
                    Goal = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DailyCalorieGoal = table.Column<int>(type: "int", nullable: false),
                    IsProfileComplete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAccounts_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CaloriesBurned = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserAccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_UserAccounts_UserAccountId",
                        column: x => x.UserAccountId,
                        principalTable: "UserAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Calories = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserAccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meals_UserAccounts_UserAccountId",
                        column: x => x.UserAccountId,
                        principalTable: "UserAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Calories = table.Column<int>(type: "int", nullable: false),
                    IsHealthy = table.Column<bool>(type: "bit", nullable: false),
                    Img = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Ingredients = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Instructions = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    Difficulty = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsFavorite = table.Column<bool>(type: "bit", nullable: false),
                    UserAccountId = table.Column<int>(type: "int", nullable: true),
                    IsGlobal = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_UserAccounts_UserAccountId",
                        column: x => x.UserAccountId,
                        principalTable: "UserAccounts",
                        principalColumn: "Id");
                });

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
                    { 11, 350, "Creamy smoothie with banana and peanut butter.", "Easy", "", "Banana, Peanut butter, Milk, Ice", "1. Add all ingredients to blender. 2. Blend until smooth.", false, true, true, "Energy boost, Quick, Protein", "Peanut Butter Banana Smoothie", "Breakfast", null },
                    { 12, 430, "Grilled chicken served with brown rice and fresh Mediterranean vegetables.", "Easy", "", "Chicken breast, Brown rice, Cucumber, Cherry tomatoes, Feta cheese, Olive oil, Lemon juice, Oregano", "1. Grill seasoned chicken breast and slice. 2. Cook brown rice. 3. Chop vegetables. 4. Assemble bowl and drizzle with olive oil and lemon.", false, true, true, "High-protein, Balanced, Meal prep", "Mediterranean Chicken Bowl", "Main", null },
                    { 13, 360, "A vegetarian wrap packed with fiber-rich chickpeas and fresh vegetables.", "Easy", "", "Whole wheat tortilla, Chickpeas, Paprika, Cumin, Lettuce, Tomato, Greek yogurt", "1. Sauté chickpeas with paprika and cumin. 2. Warm tortilla. 3. Add vegetables and yogurt. 4. Wrap tightly and serve.", false, true, true, "Vegetarian, Quick, High-fiber", "Spicy Chickpea Wrap", "Main", null },
                    { 14, 340, "High-protein oatmeal topped with berries and almond butter.", "Easy", "", "Oats, Milk, Protein powder, Blueberries, Almond butter", "1. Cook oats with milk. 2. Stir in protein powder. 3. Top with blueberries and almond butter.", false, true, true, "High-protein, Energy boost, Healthy", "Protein Oat Breakfast Bowl", "Breakfast", null },
                    { 15, 390, "Lean turkey patties grilled and seasoned with herbs.", "Medium", "", "Lean ground turkey, Garlic, Onion, Parsley, Salt, Pepper", "1. Mix turkey with seasonings. 2. Form patties. 3. Grill 5-6 minutes per side until fully cooked.", false, true, true, "High-protein, Low-fat, Dinner", "Grilled Turkey Patties", "Main", null },
                    { 16, 310, "Low-carb zucchini noodles tossed in fresh basil pesto.", "Easy", "", "Zucchini, Basil pesto, Cherry tomatoes, Parmesan", "1. Spiralize zucchini. 2. Lightly sauté for 2-3 minutes. 3. Stir in pesto and top with tomatoes and parmesan.", false, true, true, "Low-carb, Vegetarian, Light", "Zucchini Noodles with Pesto", "Main", null },
                    { 17, 350, "Oven-baked cod fillet flavored with lemon zest and fresh herbs.", "Easy", "", "Cod fillet, Olive oil, Lemon zest, Garlic, Parsley, Salt, Pepper", "1. Preheat oven to 200°C. 2. Season cod with herbs and lemon. 3. Bake 12-15 minutes until flaky.", false, true, true, "High-protein, Low-fat, Omega-3", "Baked Cod with Lemon Herbs", "Main", null },
                    { 18, 290, "Whole grain toast topped with mashed avocado and a perfectly cooked egg.", "Easy", "", "Whole grain bread, Avocado, Egg, Chili flakes, Salt", "1. Toast bread. 2. Mash avocado on top. 3. Add fried or poached egg. 4. Sprinkle chili flakes.", false, true, true, "Quick, Balanced, Healthy fats", "Avocado Egg Toast", "Breakfast", null },
                    { 19, 280, "Light homemade soup with lean chicken and fresh vegetables.", "Medium", "", "Chicken breast, Carrots, Celery, Onion, Garlic, Chicken broth", "1. Sauté vegetables. 2. Add diced chicken and broth. 3. Simmer 20 minutes until chicken is cooked.", false, true, true, "Light, High-protein, Meal prep", "Chicken and Vegetable Soup", "Soup", null },
                    { 20, 260, "Protein-rich cottage cheese topped with fresh fruit.", "Easy", "", "Cottage cheese, Pineapple, Strawberries, Chia seeds", "1. Add cottage cheese to bowl. 2. Top with fruit and chia seeds.", false, true, true, "High-protein, Quick, Healthy", "Cottage Cheese Fruit Bowl", "Snack", null },
                    { 21, 440, "Lean beef stir fried with colorful vegetables.", "Medium", "", "Lean beef strips, Bell peppers, Broccoli, Soy sauce, Garlic, Olive oil", "1. Cook beef strips in olive oil. 2. Add vegetables and stir fry 5 minutes. 3. Add soy sauce and cook 2 more minutes.", false, true, true, "High-protein, Dinner, Balanced", "Healthy Beef Stir Fry", "Main", null },
                    { 22, 310, "Fluffy omelette filled with spinach and feta cheese.", "Easy", "", "Eggs, Fresh spinach, Feta cheese, Olive oil, Salt, Pepper", "1. Whisk eggs. 2. Sauté spinach. 3. Add eggs and feta. 4. Cook until set.", false, true, true, "High-protein, Low-carb, Quick", "Spinach and Feta Omelette", "Breakfast", null },
                    { 23, 420, "Grilled shrimp served over quinoa with avocado and tomatoes.", "Medium", "", "Shrimp, Quinoa, Avocado, Cherry tomatoes, Lime juice, Olive oil", "1. Grill shrimp. 2. Cook quinoa. 3. Assemble bowl and drizzle lime juice.", false, true, true, "High-protein, Omega-3, Balanced", "Grilled Shrimp Quinoa Bowl", "Main", null },
                    { 24, 400, "Bell peppers stuffed with lean turkey and brown rice.", "Medium", "", "Bell peppers, Lean ground turkey, Spinach, Brown rice, Garlic, Tomato sauce", "1. Cook turkey with spinach. 2. Mix with rice. 3. Stuff peppers and bake 25 minutes.", false, true, true, "High-protein, Meal prep, Healthy", "Turkey and Spinach Stuffed Peppers", "Main", null },
                    { 25, 330, "Fresh salad combining chickpeas and creamy avocado.", "Easy", "", "Chickpeas, Avocado, Red onion, Lemon juice, Olive oil, Parsley", "1. Combine ingredients. 2. Toss with lemon and olive oil.", false, true, true, "Vegetarian, High-fiber, Light", "Avocado Chickpea Salad", "Salad", null },
                    { 26, 360, "Roasted sweet potato topped with garlic yogurt sauce.", "Easy", "", "Sweet potato, Greek yogurt, Garlic, Paprika, Olive oil", "1. Bake sweet potato. 2. Prepare yogurt sauce. 3. Top and serve.", false, true, true, "Vegetarian, High-fiber, Comfort food", "Baked Sweet Potato with Yogurt Sauce", "Main", null },
                    { 27, 390, "Light whole wheat wrap filled with grilled chicken and Caesar-style salad.", "Easy", "", "Grilled chicken, Whole wheat tortilla, Romaine lettuce, Light Caesar dressing, Parmesan", "1. Slice grilled chicken. 2. Add to tortilla with lettuce and dressing. 3. Sprinkle parmesan and wrap tightly.", false, true, true, "High-protein, Quick, Lunch", "Chicken Caesar Wrap Light", "Main", null },
                    { 28, 410, "Fresh Greek salad topped with seasoned grilled chicken breast.", "Easy", "", "Chicken breast, Cucumber, Tomato, Olives, Feta, Olive oil, Oregano", "1. Grill chicken and slice. 2. Chop vegetables. 3. Toss with olive oil and oregano. 4. Top with feta.", false, true, true, "High-protein, Mediterranean, Balanced", "Greek Salad with Grilled Chicken", "Salad", null },
                    { 29, 300, "Thick smoothie bowl blended with berries and protein powder.", "Easy", "", "Banana, Frozen berries, Protein powder, Almond milk, Chia seeds", "1. Blend banana, berries, protein powder and milk. 2. Pour into bowl. 3. Top with chia seeds.", false, true, true, "High-protein, Energy boost, Healthy", "Protein Smoothie Bowl", "Breakfast", null },
                    { 30, 340, "Oven-baked tilapia infused with lemon and garlic flavors.", "Easy", "", "Tilapia fillet, Lemon juice, Garlic, Olive oil, Parsley, Salt", "1. Season tilapia with garlic and lemon. 2. Bake 12-15 minutes at 200°C. 3. Garnish with parsley.", false, true, true, "Low-fat, High-protein, Dinner", "Lemon Garlic Tilapia", "Main", null },
                    { 31, 370, "Plant-based stir fry with tofu and colorful vegetables.", "Medium", "", "Firm tofu, Broccoli, Carrots, Bell peppers, Soy sauce, Sesame oil", "1. Cook tofu cubes until golden. 2. Add vegetables and stir fry 5 minutes. 3. Add soy sauce and sesame oil.", false, true, true, "Vegetarian, High-protein, Balanced", "Vegetable Stir Fry with Tofu", "Main", null },
                    { 32, 390, "Healthy brown rice fried with eggs and vegetables.", "Easy", "", "Brown rice, Eggs, Green peas, Carrots, Soy sauce, Green onion", "1. Scramble eggs in pan. 2. Add cooked rice and vegetables. 3. Stir in soy sauce and green onions.", false, true, true, "Balanced, Quick, Comfort food", "Egg Fried Brown Rice", "Main", null },
                    { 33, 420, "Low-carb salad with grilled chicken and creamy avocado.", "Easy", "", "Chicken breast, Avocado, Mixed greens, Cherry tomatoes, Olive oil, Lemon", "1. Grill chicken and slice. 2. Combine with greens and vegetables. 3. Drizzle olive oil and lemon.", false, true, true, "High-protein, Low-carb, Healthy fats", "Grilled Chicken Avocado Salad", "Salad", null },
                    { 34, 430, "Whole wheat pasta mixed with tuna and sautéed spinach.", "Easy", "", "Whole wheat pasta, Canned tuna, Spinach, Olive oil, Garlic", "1. Cook pasta. 2. Sauté garlic and spinach. 3. Mix with tuna and pasta.", false, true, true, "High-protein, Balanced, Quick", "Healthy Tuna Pasta", "Main", null },
                    { 35, 310, "Protein-rich pancakes made with cottage cheese and oats.", "Easy", "", "Cottage cheese, Eggs, Oats, Baking powder", "1. Blend all ingredients. 2. Cook small pancakes on medium heat 2-3 minutes per side.", false, true, true, "High-protein, Healthy, Quick", "Cottage Cheese Pancakes", "Breakfast", null },
                    { 36, 380, "Roasted seasonal vegetables served over quinoa.", "Medium", "", "Zucchini, Eggplant, Bell peppers, Olive oil, Quinoa", "1. Roast chopped vegetables 25 minutes at 200°C. 2. Serve over cooked quinoa.", false, true, true, "Vegetarian, High-fiber, Balanced", "Roasted Vegetable Bowl", "Main", null },
                    { 37, 450, "Crispy whole wheat quesadilla filled with chicken and avocado.", "Easy", "", "Whole wheat tortilla, Grilled chicken, Avocado, Light cheese", "1. Fill tortilla with chicken, avocado and cheese. 2. Cook in pan until crispy on both sides.", false, true, false, "High-protein, Quick, Comfort food", "Chicken and Avocado Quesadilla", "Main", null },
                    { 38, 290, "Healthy baked oatmeal cut into portable squares.", "Easy", "", "Oats, Milk, Eggs, Honey, Blueberries", "1. Mix ingredients. 2. Pour into baking dish. 3. Bake 25 minutes at 180°C and slice.", false, true, true, "High-fiber, Meal prep, Breakfast", "Baked Oatmeal Squares", "Snack", null },
                    { 39, 410, "Soft tacos filled with grilled chicken and fresh vegetables.", "Easy", "", "Chicken breast, Corn tortillas, Lettuce, Tomato, Greek yogurt", "1. Grill chicken and slice. 2. Fill tortillas with chicken and vegetables. 3. Top with yogurt.", false, true, true, "High-protein, Quick, Dinner", "Grilled Chicken Tacos", "Main", null },
                    { 40, 420, "Hearty vegetarian curry with red lentils and spinach.", "Medium", "", "Red lentils, Spinach, Onion, Garlic, Coconut milk, Curry powder", "1. Cook onion and garlic. 2. Add lentils, coconut milk and curry powder. 3. Simmer 20 minutes. 4. Stir in spinach.", false, true, true, "Vegetarian, High-fiber, Meal prep", "Lentil and Spinach Curry", "Main", null },
                    { 41, 270, "Greek yogurt bowl with apple slices, cinnamon and honey.", "Easy", "", "Greek yogurt, Apple, Cinnamon, Honey, Walnuts", "1. Add yogurt to bowl. 2. Top with apple and walnuts. 3. Sprinkle cinnamon and drizzle honey.", false, true, true, "Quick, Healthy, Light", "Apple Cinnamon Yogurt Bowl", "Snack", null },
                    { 42, 460, "Sweet and savory glazed salmon served with steamed broccoli.", "Medium", "", "Salmon fillet, Honey, Soy sauce, Garlic, Broccoli, Lemon", "1. Mix honey, soy sauce, and garlic. 2. Brush over salmon. 3. Bake at 200°C for 12-15 minutes. 4. Steam broccoli as a side.", false, true, true, "High-protein, Omega-3, Dinner", "Honey Garlic Glazed Salmon", "Main", null },
                    { 43, 210, "A lean, high-protein breakfast with fluffy egg whites and sautéed peppers.", "Easy", "", "Egg whites, Bell peppers, Spinach, Onion, Salt, Pepper", "1. Sauté peppers and onions. 2. Pour in egg whites. 3. Scramble until firm. 4. Stir in fresh spinach at the end.", false, true, true, "Low-fat, High-protein, Quick", "Egg White Veggie Scramble", "Breakfast", null },
                    { 44, 480, "Whole wheat pasta tossed with grilled chicken and a light basil pesto.", "Medium", "", "Whole wheat pasta, Chicken breast, Basil pesto, Cherry tomatoes, Pine nuts", "1. Cook pasta. 2. Grill and slice chicken. 3. Toss pasta with pesto, tomatoes, and chicken. 4. Garnish with pine nuts.", false, true, true, "High-protein, Balanced, Mediterranean", "Pesto Chicken Pasta", "Main", null },
                    { 45, 280, "Refreshing spinach salad with strawberries, blueberries, and walnuts.", "Easy", "", "Baby spinach, Strawberries, Blueberries, Walnuts, Balsamic vinaigrette", "1. Toss spinach with fresh berries. 2. Add walnuts for crunch. 3. Drizzle with balsamic vinaigrette.", false, true, true, "Vegetarian, Antioxidants, Light", "Berry Spinach Salad", "Salad", null },
                    { 46, 370, "Hearty and warming chili made with lean ground turkey and beans.", "Medium", "", "Ground turkey, Kidney beans, Diced tomatoes, Chili powder, Onion, Bell pepper", "1. Brown the turkey with onions and peppers. 2. Add tomatoes, beans, and spices. 3. Simmer for 30 minutes on low heat.", false, true, true, "High-fiber, Meal prep, High-protein", "Turkey Chili", "Main", null },
                    { 47, 330, "Elevated breakfast toast with creamy avocado and smoked salmon.", "Easy", "", "Whole grain bread, Avocado, Smoked salmon, Red onion, Capers", "1. Toast the bread. 2. Mash avocado and spread evenly. 3. Top with salmon, onion slices, and capers.", false, true, true, "Healthy fats, Omega-3, Quick", "Avocado Toast with Smoked Salmon", "Breakfast", null },
                    { 48, 410, "Lean beef strips and broccoli florets in a ginger-garlic sauce.", "Medium", "", "Beef sirloin, Broccoli, Soy sauce, Ginger, Garlic, Sesame oil", "1. Stir fry beef until browned. 2. Add broccoli and a splash of water to steam. 3. Stir in sauce and cook until thick.", false, true, true, "High-protein, Low-carb, Quick", "Beef and Broccoli", "Main", null },
                    { 49, 240, "Overnight chia pudding made with almond milk and vanilla.", "Easy", "", "Chia seeds, Almond milk, Vanilla extract, Stevia, Raspberries", "1. Mix chia seeds, milk, and vanilla. 2. Refrigerate overnight. 3. Top with raspberries before serving.", false, true, true, "High-fiber, Plant-based, Snack", "Chia Seed Pudding", "Breakfast", null },
                    { 50, 350, "Crunchy roasted chickpeas over a bed of kale and tahini dressing.", "Medium", "", "Chickpeas, Kale, Tahini, Lemon, Garlic, Olive oil", "1. Roast chickpeas until crispy. 2. Massage kale with olive oil. 3. Top kale with chickpeas and tahini dressing.", false, true, true, "Vegetarian, High-fiber, Gluten-free", "Roasted Chickpea Salad", "Salad", null },
                    { 51, 440, "Classic roasted chicken thighs with rosemary and lemon.", "Medium", "", "Chicken thighs, Rosemary, Lemon, Garlic, Butter, Salt", "1. Rub chicken with garlic and herbs. 2. Place lemon slices on top. 3. Roast at 190°C for 35-40 minutes.", false, true, true, "High-protein, Comfort food, Dinner", "Lemon Herb Roasted Chicken", "Main", null },
                    { 52, 290, "Clear vegetable soup with small pasta and Italian herbs.", "Medium", "", "Carrots, Celery, Zucchini, Tomato paste, Vegetable broth, Small pasta", "1. Sauté veggies. 2. Add broth and tomato paste. 3. Add pasta and simmer until tender.", false, true, true, "Vegetarian, Low-calorie, Healthy", "Vegetable Minestrone Soup", "Soup", null },
                    { 53, 320, "Baked eggplant layers with marinara and low-fat mozzarella.", "Medium", "", "Eggplant, Marinara sauce, Low-fat mozzarella, Parmesan, Basil", "1. Slice and bake eggplant. 2. Layer with sauce and cheese. 3. Bake until bubbly and golden.", false, true, true, "Vegetarian, Balanced, Dinner", "Eggplant Parmigiana Light", "Main", null },
                    { 54, 310, "Quick lunch featuring tuna salad served inside avocado halves.", "Easy", "", "Canned tuna, Avocado, Greek yogurt, Celery, Lime juice", "1. Mix tuna with yogurt and celery. 2. Scoop out a bit of avocado. 3. Fill with tuna mixture.", false, true, true, "Low-carb, High-protein, No-cook", "Tuna Stuffed Avocado", "Lunch", null },
                    { 55, 340, "Oatmeal that tastes like freshly baked banana bread.", "Easy", "", "Oats, Ripe banana, Walnuts, Cinnamon, Milk", "1. Cook oats with milk. 2. Stir in mashed banana and cinnamon. 3. Top with crushed walnuts.", false, true, true, "High-fiber, Vegetarian, Quick", "Banana Bread Oats", "Breakfast", null },
                    { 56, 280, "Succulent shrimp sautéed in a light garlic butter sauce.", "Easy", "", "Shrimp, Garlic, Butter, Parsley, Lemon, Red pepper flakes", "1. Sauté garlic in butter. 2. Add shrimp and cook 2 minutes per side. 3. Finish with lemon and parsley.", false, true, true, "High-protein, Low-carb, Quick", "Garlic Butter Shrimp", "Main", null },
                    { 57, 520, "A sophisticated dish featuring lean beef tenderloin wrapped in mushroom duxelles and light pastry.", "Hard", "", "Beef tenderloin, Mushrooms, Shallots, Thyme, Dijon mustard, Prosciutto (lean), Phyllo pastry, Egg wash", "1. Sear beef tenderloin on all sides and chill. 2. Finely chop mushrooms and sauté with shallots and thyme until all moisture evaporates (Duxelles). 3. Spread mustard on beef. 4. Layer prosciutto, then duxelles, then beef on plastic wrap and roll tightly into a log; chill for 1 hour. 5. Wrap the log in phyllo pastry, brush with egg wash, and bake at 200°C until the pastry is golden and internal temp is 52°C.", false, true, true, "Gourmet, High-protein, High-effort", "Beef Wellington Bites (Lean Edition)", "Main", null },
                    { 58, 480, "Fresh pasta made from scratch, filled with a delicate spinach and ricotta mixture in a light sage butter.", "Hard", "", "Type 00 flour, Eggs, Fresh spinach, Ricotta cheese, Nutmeg, Parmesan, Fresh sage, Butter, Garlic", "1. Create a flour mound, add eggs in the center, and knead for 10 minutes until smooth; rest for 30 minutes. 2. Blanch spinach, squeeze out ALL moisture, and mix with ricotta, nutmeg, and parmesan. 3. Roll pasta dough into thin sheets using a machine. 4. Place dollops of filling, fold over, seal without air bubbles, and cut into squares. 5. Boil for 3 minutes and toss in a pan with browned butter and crispy sage leaves.", false, true, true, "Vegetarian, Italian, Handmade", "Handmade Spinach & Ricotta Ravioli", "Main", null },
                    { 59, 550, "Authentic Spanish saffron rice cooked slowly with an array of fresh seafood and aromatics.", "Hard", "", "Bomba rice, Saffron threads, Shrimp, Mussels, Squid, Chicken thighs, Bell peppers, Tomatoes, Smoked paprika, Seafood stock", "1. Sauté chicken and squid in a wide paella pan; remove. 2. Create a 'sofrito' by slowly cooking onions, peppers, and grated tomatoes until dark and jammy. 3. Add rice and toast slightly, then add saffron-infused stock. 4. Simmer WITHOUT STIRRING to develop the 'socarrat' (crispy bottom). 5. Arrange shrimp and mussels on top for the last 8 minutes, allowing them to steam as the liquid disappears.", false, true, true, "Seafood, Spanish, One-pan", "Traditional Seafood Paella", "Main", null },
                    { 60, 410, "A deep, rich soup requiring hours of onion caramelization for a complex, sweet-savory flavor profile.", "Hard", "", "Yellow onions (2kg), Beef bone broth, Dry white wine, Cognac, Flour, Thyme, Bay leaf, Baguette slices, Gruyère cheese", "1. Slice onions thinly and cook in a heavy pot on low heat for 60-90 minutes, stirring occasionally until deep mahogany brown. 2. Deglaze with cognac and white wine, scraping the bottom. 3. Stir in flour, then slowly add beef broth and herbs. 4. Simmer for 45 minutes to develop depth. 5. Ladle into oven-safe bowls, top with toasted baguette and a thick layer of Gruyère, and broil until bubbly and charred.", false, true, false, "French, Comfort food, High-effort", "French Onion Soup (Authentic)", "Soup", null },
                    { 61, 620, "Slow-cooked lamb shanks that fall off the bone, served in a reduced wine and root vegetable jus.", "Hard", "", "Lamb shanks, Red wine (Cabernet), Carrots, Celery, Leeks, Garlic, Rosemary, Tomato paste, Lamb stock", "1. Season and brown lamb shanks deeply in a Dutch oven; remove. 2. Sauté mirepoix (carrots, celery, leeks) until soft. 3. Add tomato paste and cook until it darkens. 4. Return lamb to the pot, cover halfway with wine and stock. 5. Braise at 150°C for 3.5 hours. 6. Strain the liquid into a saucepan and reduce by half until it coats a spoon; pour over the lamb to serve.", false, true, true, "High-protein, Slow-cook, Gourmet", "Braised Lamb Shanks in Red Wine", "Main", null },
                    { 62, 580, "A labor-intensive Greek classic with spiced meat sauce, fried eggplant, and thick béchamel topping.", "Hard", "", "Eggplants, Potatoes, Ground lamb, Cinnamon, Allspice, Onions, Red wine, Milk, Flour, Butter, Egg yolks, Kefalotyri cheese", "1. Slice and salt eggplants to remove bitterness; rinse and bake until soft. 2. Fry potato slices for the base layer. 3. Cook lamb with onions, wine, and warm spices (cinnamon/allspice) until thick. 4. Make a roux with butter and flour, whisk in milk until thick, then temper with egg yolks and cheese for the béchamel. 5. Layer potatoes, meat, eggplant, then béchamel; bake at 180°C for 50 minutes until golden brown.", false, true, false, "Greek, Traditional, Layered", "Eggplant Moussaka (Layered)", "Main", null },
                    { 63, 320, "Restaurant-quality cold appetizer requiring precision knife work and fresh, high-grade ingredients.", "Hard", "", "Sashimi-grade Ahi Tuna, Shallots, Chives, Ginger, Soy sauce, Sesame oil, Lime, Ripe avocado, Wasabi, Microgreens", "1. Chill all equipment. 2. Use a razor-sharp knife to dice tuna into perfect 5mm cubes. 3. Mix tuna with finely minced shallots, chives, ginger, and dressing. 4. Blend avocado with lime and wasabi until completely smooth; pass through a fine sieve. 5. Use a ring mold to layer the tuna on a plate, top with dots of avocado mousse using a piping bag, and garnish with microgreens.", false, true, true, "Seafood, Low-carb, Precision", "Tuna Tartare with Avocado Mousse", "Appetizer", null },
                    { 64, 450, "A technical Italian dish requiring constant attention to achieve the perfect 'all'onda' consistency.", "Hard", "", "Arborio rice, Dried porcini, Fresh cremini, Shiitake, Shallots, Dry vermouth, Mushroom stock, Butter, Parmesan, Truffle oil", "1. Rehydrate porcini and keep stock simmering nearby. 2. Sauté mushrooms in batches to ensure browning; remove. 3. Toast rice with shallots until edges are translucent. 4. Add vermouth and reduce. 5. Add stock ONE LADLE AT A TIME, stirring constantly to release starch. 6. Once rice is al dente, vigorously beat in cold butter and parmesan (Mantucatura) to create a creamy sauce. 7. Drizzle with truffle oil.", false, true, true, "Vegetarian, Italian, Technique", "Wild Mushroom Risotto with Truffle Oil", "Main", null },
                    { 65, 490, "Vietnamese noodle soup featuring a clear, deeply aromatic broth made from charred aromatics and bones.", "Hard", "", "Beef marrow bones, Star anise, Cinnamon sticks, Cardamom, Charred ginger, Charred onion, Rice noodles, Flank steak, Fish sauce", "1. Parboil bones for 10 minutes, then scrub clean to ensure a clear broth. 2. Simmer bones for 12-24 hours, skimming fat constantly. 3. Toast spices and add to broth with charred ginger and onion for the final 4 hours. 4. Strain through a cheesecloth and season with fish sauce. 5. Serve with blanched rice noodles, paper-thin raw steak slices (cooked by the hot broth), and fresh herbs.", false, true, true, "Vietnamese, High-effort, Aromatic", "Authentic Pho (24-Hour Broth)", "Soup", null },
                    { 66, 540, "Technical dish combining modern sous-vide precision with classic French sauce reduction.", "Hard", "", "Duck breast, Fresh cherries, Red wine vinegar, Sugar, Port wine, Star anise, Thyme, Parsnip puree", "1. Score duck skin in a diamond pattern without hitting the meat. 2. Vacuum seal with thyme and cook in water bath at 54°C for 2 hours. 3. Create a gastrique by caramelizing sugar, deglazing with vinegar and port, and reducing with cherries until syrupy. 4. Sear duck in a cold pan, rendering out all fat until skin is paper-thin and crispy. 5. Rest meat, slice, and serve over parsnip puree with the reduction.", false, true, true, "Gourmet, Precision, French", "Sous-Vide Duck Breast with Cherry Gastrique", "Main", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_UserAccountId",
                table: "Activities",
                column: "UserAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_UserAccountId",
                table: "Meals",
                column: "UserAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_UserAccountId",
                table: "Recipes",
                column: "UserAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccounts_IdentityUserId",
                table: "UserAccounts",
                column: "IdentityUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "UserAccounts");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
