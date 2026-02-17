using CalorieCore.DataModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CalorieCore.Data.Migrations
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserActivity> Activities { get; set; } = null!;
        public DbSet<Recipe> Recipes { get; set; } = null!;
        public DbSet<UserAccount> UserAccounts { get; set; } = null!;
        public DbSet<Meal> Meals { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserAccount>()
    .HasOne(u => u.IdentityUser)
    .WithMany()
    .HasForeignKey(u => u.IdentityUserId)
    .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Recipe>().HasData(
                new Recipe
                {
                    Id = 1,
                    Title = "Grilled Chicken Salad",
                    Description = "Fresh mixed greens topped with grilled chicken breast and light vinaigrette.",
                    Calories = 350,
                    Type = "Salad",
                    Difficulty = "Easy",
                    Tags = "High-protein, Low-carb, Light",
                    Ingredients = "Chicken breast, Mixed greens, Cherry tomatoes, Cucumber, Olive oil, Lemon juice",
                    Instructions = "1. Grill chicken and slice. 2. Chop vegetables. 3. Toss with olive oil and lemon dressing.",
                    IsHealthy = true,
                    IsFavorite = false,
                    Img = "",
                    UserAccountId = null,
                    IsGlobal = true
                },

new Recipe
{
    Id = 2,
    Title = "Oatmeal with Berries",
    Description = "Classic oatmeal topped with fresh berries and honey.",
    Calories = 280,
    Type = "Breakfast",
    Difficulty = "Easy",
    Tags = "High-fiber, Quick, Healthy",
    Ingredients = "Oats, Milk, Blueberries, Strawberries, Honey",
    Instructions = "1. Cook oats with milk. 2. Top with berries. 3. Drizzle honey.",
    IsHealthy = true,
    IsFavorite = false,
    Img = "",
    UserAccountId = null,
    IsGlobal = true
},

new Recipe
{
    Id = 3,
    Title = "Quinoa Vegetable Bowl",
    Description = "Nutritious quinoa bowl with roasted vegetables.",
    Calories = 400,
    Type = "Main",
    Difficulty = "Medium",
    Tags = "Vegetarian, High-fiber, Balanced",
    Ingredients = "Quinoa, Zucchini, Bell peppers, Carrots, Olive oil",
    Instructions = "1. Cook quinoa. 2. Roast vegetables. 3. Combine and drizzle olive oil.",
    IsHealthy = true,
    IsFavorite = false,
    Img = "",
    UserAccountId = null,
    IsGlobal = true
},

new Recipe
{
    Id = 4,
    Title = "Greek Yogurt Parfait",
    Description = "Layered Greek yogurt with granola and fresh fruit.",
    Calories = 300,
    Type = "Snack",
    Difficulty = "Easy",
    Tags = "High-protein, Quick, Healthy",
    Ingredients = "Greek yogurt, Granola, Mixed berries, Honey",
    Instructions = "1. Layer yogurt and granola. 2. Add berries. 3. Drizzle honey.",
    IsHealthy = true,
    IsFavorite = false,
    Img = "",
    UserAccountId = null,
    IsGlobal = true
},

new Recipe
{
    Id = 5,
    Title = "Baked Salmon with Asparagus",
    Description = "Oven-baked salmon served with roasted asparagus.",
    Calories = 450,
    Type = "Main",
    Difficulty = "Medium",
    Tags = "High-protein, Omega-3, Low-carb",
    Ingredients = "Salmon fillet, Asparagus, Olive oil, Lemon, Garlic",
    Instructions = "1. Season salmon. 2. Bake at 200°C for 15 minutes. 3. Roast asparagus alongside.",
    IsHealthy = true,
    IsFavorite = false,
    Img = "",
    UserAccountId = null,
    IsGlobal = true
},

new Recipe
{
    Id = 6,
    Title = "Chicken Stir Fry",
    Description = "Quick stir fry with chicken and colorful vegetables.",
    Calories = 420,
    Type = "Main",
    Difficulty = "Medium",
    Tags = "High-protein, Quick, Balanced",
    Ingredients = "Chicken breast, Broccoli, Carrots, Bell peppers, Soy sauce",
    Instructions = "1. Cook chicken strips. 2. Add vegetables. 3. Stir in soy sauce and cook until tender.",
    IsHealthy = true,
    IsFavorite = false,
    Img = "",
    UserAccountId = null,
    IsGlobal = true
},

new Recipe
{
    Id = 7,
    Title = "Turkey Avocado Sandwich",
    Description = "Whole grain sandwich with turkey and fresh avocado.",
    Calories = 380,
    Type = "Lunch",
    Difficulty = "Easy",
    Tags = "High-protein, Quick, Balanced",
    Ingredients = "Whole grain bread, Turkey slices, Avocado, Lettuce, Tomato",
    Instructions = "1. Toast bread. 2. Add turkey and sliced avocado. 3. Top with lettuce and tomato.",
    IsHealthy = true,
    IsFavorite = false,
    Img = "",
    UserAccountId = null,
    IsGlobal = true
},

new Recipe
{
    Id = 8,
    Title = "Veggie Omelette",
    Description = "Egg omelette filled with fresh vegetables.",
    Calories = 290,
    Type = "Breakfast",
    Difficulty = "Easy",
    Tags = "Low-carb, High-protein, Quick",
    Ingredients = "Eggs, Spinach, Mushrooms, Bell peppers, Olive oil",
    Instructions = "1. Whisk eggs. 2. Sauté vegetables. 3. Pour eggs over vegetables and cook until set.",
    IsHealthy = true,
    IsFavorite = false,
    Img = "",
    UserAccountId = null,
    IsGlobal = true
},

new Recipe
{
    Id = 9,
    Title = "Lentil Soup",
    Description = "Hearty lentil soup packed with fiber and nutrients.",
    Calories = 330,
    Type = "Soup",
    Difficulty = "Medium",
    Tags = "Vegetarian, High-fiber, Meal prep",
    Ingredients = "Red lentils, Onion, Carrots, Garlic, Vegetable broth",
    Instructions = "1. Sauté onion and garlic. 2. Add lentils and broth. 3. Simmer 25 minutes.",
    IsHealthy = true,
    IsFavorite = false,
    Img = "",
    UserAccountId = null,
    IsGlobal = true
},

new Recipe
{
    Id = 10,
    Title = "Caprese Salad",
    Description = "Simple Italian salad with mozzarella and tomatoes.",
    Calories = 320,
    Type = "Salad",
    Difficulty = "Easy",
    Tags = "Vegetarian, Fresh, Light",
    Ingredients = "Mozzarella, Tomatoes, Fresh basil, Olive oil, Balsamic glaze",
    Instructions = "1. Slice mozzarella and tomatoes. 2. Layer with basil. 3. Drizzle olive oil and balsamic.",
    IsHealthy = true,
    IsFavorite = false,
    Img = "",
    UserAccountId = null,
    IsGlobal = true
},

new Recipe
{
    Id = 11,
    Title = "Peanut Butter Banana Smoothie",
    Description = "Creamy smoothie with banana and peanut butter.",
    Calories = 350,
    Type = "Breakfast",
    Difficulty = "Easy",
    Tags = "Energy boost, Quick, Protein",
    Ingredients = "Banana, Peanut butter, Milk, Ice",
    Instructions = "1. Add all ingredients to blender. 2. Blend until smooth.",
    IsHealthy = true,
    IsFavorite = false,
    Img = "",
    UserAccountId = null,
    IsGlobal = true
},


                new Recipe
                {
                    Id = 12,
                    Title = "Mediterranean Chicken Bowl",
                    Description = "Grilled chicken served with brown rice and fresh Mediterranean vegetables.",
                    Calories = 430,
                    Type = "Main",
                    Difficulty = "Easy",
                    Tags = "High-protein, Balanced, Meal prep",
                    Ingredients = "Chicken breast, Brown rice, Cucumber, Cherry tomatoes, Feta cheese, Olive oil, Lemon juice, Oregano",
                    Instructions = "1. Grill seasoned chicken breast and slice. 2. Cook brown rice. 3. Chop vegetables. 4. Assemble bowl and drizzle with olive oil and lemon.",
                    IsHealthy = true,
                    IsFavorite = false,
                    Img = "",
                    UserAccountId = null,
                    IsGlobal = true
                },

                new Recipe
                {
                    Id = 13,
                    Title = "Spicy Chickpea Wrap",
                    Description = "A vegetarian wrap packed with fiber-rich chickpeas and fresh vegetables.",
                    Calories = 360,
                    Type = "Main",
                    Difficulty = "Easy",
                    Tags = "Vegetarian, Quick, High-fiber",
                    Ingredients = "Whole wheat tortilla, Chickpeas, Paprika, Cumin, Lettuce, Tomato, Greek yogurt",
                    Instructions = "1. Sauté chickpeas with paprika and cumin. 2. Warm tortilla. 3. Add vegetables and yogurt. 4. Wrap tightly and serve.",
                    IsHealthy = true,
                    IsFavorite = false,
                    Img = "",
                    UserAccountId = null,
                    IsGlobal = true
                },

                new Recipe
                {
                    Id = 14,
                    Title = "Protein Oat Breakfast Bowl",
                    Description = "High-protein oatmeal topped with berries and almond butter.",
                    Calories = 340,
                    Type = "Breakfast",
                    Difficulty = "Easy",
                    Tags = "High-protein, Energy boost, Healthy",
                    Ingredients = "Oats, Milk, Protein powder, Blueberries, Almond butter",
                    Instructions = "1. Cook oats with milk. 2. Stir in protein powder. 3. Top with blueberries and almond butter.",
                    IsHealthy = true,
                    IsFavorite = false,
                    Img = "",
                    UserAccountId = null,
                    IsGlobal = true
                },

                new Recipe
                {
                    Id = 15,
                    Title = "Grilled Turkey Patties",
                    Description = "Lean turkey patties grilled and seasoned with herbs.",
                    Calories = 390,
                    Type = "Main",
                    Difficulty = "Medium",
                    Tags = "High-protein, Low-fat, Dinner",
                    Ingredients = "Lean ground turkey, Garlic, Onion, Parsley, Salt, Pepper",
                    Instructions = "1. Mix turkey with seasonings. 2. Form patties. 3. Grill 5-6 minutes per side until fully cooked.",
                    IsHealthy = true,
                    IsFavorite = false,
                    Img = "",
                    UserAccountId = null,
                    IsGlobal = true
                },

                new Recipe
                {
                    Id = 16,
                    Title = "Zucchini Noodles with Pesto",
                    Description = "Low-carb zucchini noodles tossed in fresh basil pesto.",
                    Calories = 310,
                    Type = "Main",
                    Difficulty = "Easy",
                    Tags = "Low-carb, Vegetarian, Light",
                    Ingredients = "Zucchini, Basil pesto, Cherry tomatoes, Parmesan",
                    Instructions = "1. Spiralize zucchini. 2. Lightly sauté for 2-3 minutes. 3. Stir in pesto and top with tomatoes and parmesan.",
                    IsHealthy = true,
                    IsFavorite = false,
                    Img = "",
                    UserAccountId = null,
                    IsGlobal = true
                },
new Recipe
{
Id = 17,
Title = "Baked Cod with Lemon Herbs",
Description = "Oven-baked cod fillet flavored with lemon zest and fresh herbs.",
Calories = 350,
Type = "Main",
Difficulty = "Easy",
Tags = "High-protein, Low-fat, Omega-3",
Ingredients = "Cod fillet, Olive oil, Lemon zest, Garlic, Parsley, Salt, Pepper",
Instructions = "1. Preheat oven to 200°C. 2. Season cod with herbs and lemon. 3. Bake 12-15 minutes until flaky.",
IsHealthy = true,
IsFavorite = false,
Img = "",
UserAccountId = null,
IsGlobal = true
},

new Recipe
{
    Id = 18,
    Title = "Avocado Egg Toast",
    Description = "Whole grain toast topped with mashed avocado and a perfectly cooked egg.",
    Calories = 290,
    Type = "Breakfast",
    Difficulty = "Easy",
    Tags = "Quick, Balanced, Healthy fats",
    Ingredients = "Whole grain bread, Avocado, Egg, Chili flakes, Salt",
    Instructions = "1. Toast bread. 2. Mash avocado on top. 3. Add fried or poached egg. 4. Sprinkle chili flakes.",
    IsHealthy = true,
    IsFavorite = false,
    Img = "",
    UserAccountId = null,
    IsGlobal = true
},

new Recipe
{
    Id = 19,
    Title = "Chicken and Vegetable Soup",
    Description = "Light homemade soup with lean chicken and fresh vegetables.",
    Calories = 280,
    Type = "Soup",
    Difficulty = "Medium",
    Tags = "Light, High-protein, Meal prep",
    Ingredients = "Chicken breast, Carrots, Celery, Onion, Garlic, Chicken broth",
    Instructions = "1. Sauté vegetables. 2. Add diced chicken and broth. 3. Simmer 20 minutes until chicken is cooked.",
    IsHealthy = true,
    IsFavorite = false,
    Img = "",
    UserAccountId = null,
    IsGlobal = true
},

new Recipe
{
    Id = 20,
    Title = "Cottage Cheese Fruit Bowl",
    Description = "Protein-rich cottage cheese topped with fresh fruit.",
    Calories = 260,
    Type = "Snack",
    Difficulty = "Easy",
    Tags = "High-protein, Quick, Healthy",
    Ingredients = "Cottage cheese, Pineapple, Strawberries, Chia seeds",
    Instructions = "1. Add cottage cheese to bowl. 2. Top with fruit and chia seeds.",
    IsHealthy = true,
    IsFavorite = false,
    Img = "",
    UserAccountId = null,
    IsGlobal = true
},

new Recipe
{
    Id = 21,
    Title = "Healthy Beef Stir Fry",
    Description = "Lean beef stir fried with colorful vegetables.",
    Calories = 440,
    Type = "Main",
    Difficulty = "Medium",
    Tags = "High-protein, Dinner, Balanced",
    Ingredients = "Lean beef strips, Bell peppers, Broccoli, Soy sauce, Garlic, Olive oil",
    Instructions = "1. Cook beef strips in olive oil. 2. Add vegetables and stir fry 5 minutes. 3. Add soy sauce and cook 2 more minutes.",
    IsHealthy = true,
    IsFavorite = false,
    Img = "",
    UserAccountId = null,
    IsGlobal = true
},

new Recipe
{
    Id = 22,
    Title = "Spinach and Feta Omelette",
    Description = "Fluffy omelette filled with spinach and feta cheese.",
    Calories = 310,
    Type = "Breakfast",
    Difficulty = "Easy",
    Tags = "High-protein, Low-carb, Quick",
    Ingredients = "Eggs, Fresh spinach, Feta cheese, Olive oil, Salt, Pepper",
    Instructions = "1. Whisk eggs. 2. Sauté spinach. 3. Add eggs and feta. 4. Cook until set.",
    IsHealthy = true,
    IsFavorite = false,
    Img = "",
    UserAccountId = null,
    IsGlobal = true
},

new Recipe
{
    Id = 23,
    Title = "Grilled Shrimp Quinoa Bowl",
    Description = "Grilled shrimp served over quinoa with avocado and tomatoes.",
    Calories = 420,
    Type = "Main",
    Difficulty = "Medium",
    Tags = "High-protein, Omega-3, Balanced",
    Ingredients = "Shrimp, Quinoa, Avocado, Cherry tomatoes, Lime juice, Olive oil",
    Instructions = "1. Grill shrimp. 2. Cook quinoa. 3. Assemble bowl and drizzle lime juice.",
    IsHealthy = true,
    IsFavorite = false,
    Img = "",
    UserAccountId = null,
    IsGlobal = true
},

new Recipe
{
    Id = 24,
    Title = "Turkey and Spinach Stuffed Peppers",
    Description = "Bell peppers stuffed with lean turkey and brown rice.",
    Calories = 400,
    Type = "Main",
    Difficulty = "Medium",
    Tags = "High-protein, Meal prep, Healthy",
    Ingredients = "Bell peppers, Lean ground turkey, Spinach, Brown rice, Garlic, Tomato sauce",
    Instructions = "1. Cook turkey with spinach. 2. Mix with rice. 3. Stuff peppers and bake 25 minutes.",
    IsHealthy = true,
    IsFavorite = false,
    Img = "",
    UserAccountId = null,
    IsGlobal = true
},

new Recipe
{
    Id = 25,
    Title = "Avocado Chickpea Salad",
    Description = "Fresh salad combining chickpeas and creamy avocado.",
    Calories = 330,
    Type = "Salad",
    Difficulty = "Easy",
    Tags = "Vegetarian, High-fiber, Light",
    Ingredients = "Chickpeas, Avocado, Red onion, Lemon juice, Olive oil, Parsley",
    Instructions = "1. Combine ingredients. 2. Toss with lemon and olive oil.",
    IsHealthy = true,
    IsFavorite = false,
    Img = "",
    UserAccountId = null,
    IsGlobal = true
},

new Recipe
{
    Id = 26,
    Title = "Baked Sweet Potato with Yogurt Sauce",
    Description = "Roasted sweet potato topped with garlic yogurt sauce.",
    Calories = 360,
    Type = "Main",
    Difficulty = "Easy",
    Tags = "Vegetarian, High-fiber, Comfort food",
    Ingredients = "Sweet potato, Greek yogurt, Garlic, Paprika, Olive oil",
    Instructions = "1. Bake sweet potato. 2. Prepare yogurt sauce. 3. Top and serve.",
    IsHealthy = true,
    IsFavorite = false,
    Img = "",
    UserAccountId = null,
    IsGlobal = true
},
new Recipe
{
    Id = 27,
    Title = "Chicken Caesar Wrap Light",
    Description = "Light whole wheat wrap filled with grilled chicken and Caesar-style salad.",
    Calories = 390,
    Type = "Main",
    Difficulty = "Easy",
    Tags = "High-protein, Quick, Lunch",
    Ingredients = "Grilled chicken, Whole wheat tortilla, Romaine lettuce, Light Caesar dressing, Parmesan",
    Instructions = "1. Slice grilled chicken. 2. Add to tortilla with lettuce and dressing. 3. Sprinkle parmesan and wrap tightly.",
    IsHealthy = true,
    IsFavorite = false,
    Img = "",
    UserAccountId = null,
    IsGlobal = true
},

new Recipe
{
    Id = 28,
    Title = "Greek Salad with Grilled Chicken",
    Description = "Fresh Greek salad topped with seasoned grilled chicken breast.",
    Calories = 410,
    Type = "Salad",
    Difficulty = "Easy",
    Tags = "High-protein, Mediterranean, Balanced",
    Ingredients = "Chicken breast, Cucumber, Tomato, Olives, Feta, Olive oil, Oregano",
    Instructions = "1. Grill chicken and slice. 2. Chop vegetables. 3. Toss with olive oil and oregano. 4. Top with feta.",
    IsHealthy = true,
    IsFavorite = false,
    Img = "",
    UserAccountId = null,
    IsGlobal = true
},

new Recipe
{
    Id = 29,
    Title = "Protein Smoothie Bowl",
    Description = "Thick smoothie bowl blended with berries and protein powder.",
    Calories = 300,
    Type = "Breakfast",
    Difficulty = "Easy",
    Tags = "High-protein, Energy boost, Healthy",
    Ingredients = "Banana, Frozen berries, Protein powder, Almond milk, Chia seeds",
    Instructions = "1. Blend banana, berries, protein powder and milk. 2. Pour into bowl. 3. Top with chia seeds.",
    IsHealthy = true,
    IsFavorite = false,
    Img = "",
    UserAccountId = null,
    IsGlobal = true
},

new Recipe
{
    Id = 30,
    Title = "Lemon Garlic Tilapia",
    Description = "Oven-baked tilapia infused with lemon and garlic flavors.",
    Calories = 340,
    Type = "Main",
    Difficulty = "Easy",
    Tags = "Low-fat, High-protein, Dinner",
    Ingredients = "Tilapia fillet, Lemon juice, Garlic, Olive oil, Parsley, Salt",
    Instructions = "1. Season tilapia with garlic and lemon. 2. Bake 12-15 minutes at 200°C. 3. Garnish with parsley.",
    IsHealthy = true,
    IsFavorite = false,
    Img = "",
    UserAccountId = null,
    IsGlobal = true
},

new Recipe
{
    Id = 31,
    Title = "Vegetable Stir Fry with Tofu",
    Description = "Plant-based stir fry with tofu and colorful vegetables.",
    Calories = 370,
    Type = "Main",
    Difficulty = "Medium",
    Tags = "Vegetarian, High-protein, Balanced",
    Ingredients = "Firm tofu, Broccoli, Carrots, Bell peppers, Soy sauce, Sesame oil",
    Instructions = "1. Cook tofu cubes until golden. 2. Add vegetables and stir fry 5 minutes. 3. Add soy sauce and sesame oil.",
    IsHealthy = true,
    IsFavorite = false,
    Img = "",
    UserAccountId = null,
    IsGlobal = true
},

new Recipe
{
    Id = 32,
    Title = "Egg Fried Brown Rice",
    Description = "Healthy brown rice fried with eggs and vegetables.",
    Calories = 390,
    Type = "Main",
    Difficulty = "Easy",
    Tags = "Balanced, Quick, Comfort food",
    Ingredients = "Brown rice, Eggs, Green peas, Carrots, Soy sauce, Green onion",
    Instructions = "1. Scramble eggs in pan. 2. Add cooked rice and vegetables. 3. Stir in soy sauce and green onions.",
    IsHealthy = true,
    IsFavorite = false,
    Img = "",
    UserAccountId = null,
    IsGlobal = true
},

new Recipe
{
    Id = 33,
    Title = "Grilled Chicken Avocado Salad",
    Description = "Low-carb salad with grilled chicken and creamy avocado.",
    Calories = 420,
    Type = "Salad",
    Difficulty = "Easy",
    Tags = "High-protein, Low-carb, Healthy fats",
    Ingredients = "Chicken breast, Avocado, Mixed greens, Cherry tomatoes, Olive oil, Lemon",
    Instructions = "1. Grill chicken and slice. 2. Combine with greens and vegetables. 3. Drizzle olive oil and lemon.",
    IsHealthy = true,
    IsFavorite = false,
    Img = "",
    UserAccountId = null,
    IsGlobal = true
},

new Recipe
{
    Id = 34,
    Title = "Healthy Tuna Pasta",
    Description = "Whole wheat pasta mixed with tuna and sautéed spinach.",
    Calories = 430,
    Type = "Main",
    Difficulty = "Easy",
    Tags = "High-protein, Balanced, Quick",
    Ingredients = "Whole wheat pasta, Canned tuna, Spinach, Olive oil, Garlic",
    Instructions = "1. Cook pasta. 2. Sauté garlic and spinach. 3. Mix with tuna and pasta.",
    IsHealthy = true,
    IsFavorite = false,
    Img = "",
    UserAccountId = null,
    IsGlobal = true
},

new Recipe
{
    Id = 35,
    Title = "Cottage Cheese Pancakes",
    Description = "Protein-rich pancakes made with cottage cheese and oats.",
    Calories = 310,
    Type = "Breakfast",
    Difficulty = "Easy",
    Tags = "High-protein, Healthy, Quick",
    Ingredients = "Cottage cheese, Eggs, Oats, Baking powder",
    Instructions = "1. Blend all ingredients. 2. Cook small pancakes on medium heat 2-3 minutes per side.",
    IsHealthy = true,
    IsFavorite = false,
    Img = "",
    UserAccountId = null,
    IsGlobal = true
},

new Recipe
{
    Id = 36,
    Title = "Roasted Vegetable Bowl",
    Description = "Roasted seasonal vegetables served over quinoa.",
    Calories = 380,
    Type = "Main",
    Difficulty = "Medium",
    Tags = "Vegetarian, High-fiber, Balanced",
    Ingredients = "Zucchini, Eggplant, Bell peppers, Olive oil, Quinoa",
    Instructions = "1. Roast chopped vegetables 25 minutes at 200°C. 2. Serve over cooked quinoa.",
    IsHealthy = true,
    IsFavorite = false,
    Img = "",
    UserAccountId = null,
    IsGlobal = true
},

new Recipe
{
    Id = 37,
    Title = "Chicken and Avocado Quesadilla",
    Description = "Crispy whole wheat quesadilla filled with chicken and avocado.",
    Calories = 450,
    Type = "Main",
    Difficulty = "Easy",
    Tags = "High-protein, Quick, Comfort food",
    Ingredients = "Whole wheat tortilla, Grilled chicken, Avocado, Light cheese",
    Instructions = "1. Fill tortilla with chicken, avocado and cheese. 2. Cook in pan until crispy on both sides.",
    IsHealthy = false,
    IsFavorite = false,
    Img = "",
    UserAccountId = null,
    IsGlobal = true
},

new Recipe
{
    Id = 38,
    Title = "Baked Oatmeal Squares",
    Description = "Healthy baked oatmeal cut into portable squares.",
    Calories = 290,
    Type = "Snack",
    Difficulty = "Easy",
    Tags = "High-fiber, Meal prep, Breakfast",
    Ingredients = "Oats, Milk, Eggs, Honey, Blueberries",
    Instructions = "1. Mix ingredients. 2. Pour into baking dish. 3. Bake 25 minutes at 180°C and slice.",
    IsHealthy = true,
    IsFavorite = false,
    Img = "",
    UserAccountId = null,
    IsGlobal = true
},

new Recipe
{
    Id = 39,
    Title = "Grilled Chicken Tacos",
    Description = "Soft tacos filled with grilled chicken and fresh vegetables.",
    Calories = 410,
    Type = "Main",
    Difficulty = "Easy",
    Tags = "High-protein, Quick, Dinner",
    Ingredients = "Chicken breast, Corn tortillas, Lettuce, Tomato, Greek yogurt",
    Instructions = "1. Grill chicken and slice. 2. Fill tortillas with chicken and vegetables. 3. Top with yogurt.",
    IsHealthy = true,
    IsFavorite = false,
    Img = "",
    UserAccountId = null,
    IsGlobal = true
},

new Recipe
{
    Id = 40,
    Title = "Lentil and Spinach Curry",
    Description = "Hearty vegetarian curry with red lentils and spinach.",
    Calories = 420,
    Type = "Main",
    Difficulty = "Medium",
    Tags = "Vegetarian, High-fiber, Meal prep",
    Ingredients = "Red lentils, Spinach, Onion, Garlic, Coconut milk, Curry powder",
    Instructions = "1. Cook onion and garlic. 2. Add lentils, coconut milk and curry powder. 3. Simmer 20 minutes. 4. Stir in spinach.",
    IsHealthy = true,
    IsFavorite = false,
    Img = "",
    UserAccountId = null,
    IsGlobal = true
},


new Recipe
{
    Id = 41,
    Title = "Apple Cinnamon Yogurt Bowl",
    Description = "Greek yogurt bowl with apple slices, cinnamon and honey.",
    Calories = 270,
    Type = "Snack",
    Difficulty = "Easy",
    Tags = "Quick, Healthy, Light",
    Ingredients = "Greek yogurt, Apple, Cinnamon, Honey, Walnuts",
    Instructions = "1. Add yogurt to bowl. 2. Top with apple and walnuts. 3. Sprinkle cinnamon and drizzle honey.",
    IsHealthy = true,
    IsFavorite = false,
    Img = "",
    UserAccountId = null,
    IsGlobal = true
}

            );
        }
    }
}
