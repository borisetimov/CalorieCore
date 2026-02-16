using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CalorieCore.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddRoles : Migration
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
                    { 41, 270, "Greek yogurt bowl with apple slices, cinnamon and honey.", "Easy", "", "Greek yogurt, Apple, Cinnamon, Honey, Walnuts", "1. Add yogurt to bowl. 2. Top with apple and walnuts. 3. Sprinkle cinnamon and drizzle honey.", false, true, true, "Quick, Healthy, Light", "Apple Cinnamon Yogurt Bowl", "Snack", null }
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
