using CalorieTrackerApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CalorieTrackerApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<UserActivity> Activities { get; set; } = null!;
        public DbSet<Recipe> Recipes { get; set; } = null!;
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<Meal> Meals { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
          modelBuilder.Entity<Recipe>().HasData(
                new Recipe
                {
                    Id = 1,
                    Title = "Grilled Chicken Salad",
                    Description = "Healthy salad with grilled chicken, fresh greens, and light dressing.",
                    Calories = 350,
                    IsHealthy = true,
                    Img = ""
                },
    new Recipe
    {
        Id = 2,
        Title = "Avocado Toast",
        Description = "Whole-grain toast topped with avocado and cherry tomatoes.",
        Calories = 250,
        IsHealthy = true,
        Img = ""
    },
    new Recipe
    {
        Id = 3,
        Title = "Pasta Carbonara",
        Description = "Classic Italian pasta with creamy sauce and pancetta.",
        Calories = 650,
        IsHealthy = false,
        Img = ""
    },
    new Recipe
    {
        Id = 4,
        Title = "Smoothie Bowl",
        Description = "Fruit smoothie bowl with granola and berries.",
        Calories = 300,
        IsHealthy = true,
        Img = ""
    },

    new Recipe
    {
        Id = 5,
        Title = "Oatmeal with Fruits",
        Description = "Warm oatmeal topped with banana, berries, and honey.",
        Calories = 280,
        IsHealthy = true,
        Img = ""
    },
    new Recipe
    {
        Id = 6,
        Title = "Greek Yogurt Parfait",
        Description = "Greek yogurt layered with granola and fresh fruits.",
        Calories = 220,
        IsHealthy = true,
        Img = ""
    },
    new Recipe
    {
        Id = 7,
        Title = "Beef Stir Fry",
        Description = "Beef strips stir-fried with vegetables and soy sauce.",
        Calories = 550,
        IsHealthy = false,
        Img = ""
    },
    new Recipe
    {
        Id = 8,
        Title = "Vegetable Omelette",
        Description = "Egg omelette with peppers, onions, and mushrooms.",
        Calories = 320,
        IsHealthy = true,
        Img = ""
    },
    new Recipe
    {
        Id = 9,
        Title = "Chicken Wrap",
        Description = "Whole-wheat wrap with grilled chicken and veggies.",
        Calories = 420,
        IsHealthy = true,
        Img = ""
    },
    new Recipe
    {
        Id = 10,
        Title = "Cheeseburger",
        Description = "Classic beef cheeseburger with bun and cheese.",
        Calories = 700,
        IsHealthy = false,
        Img = ""
    },
    new Recipe
    {
        Id = 11,
        Title = "Salmon with Rice",
        Description = "Grilled salmon served with rice and vegetables.",
        Calories = 480,
        IsHealthy = true,
        Img = ""
    },
    new Recipe
    {
        Id = 12,
        Title = "Quinoa Salad",
        Description = "Quinoa mixed with cucumber, tomato, and olive oil.",
        Calories = 340,
        IsHealthy = true,
        Img = ""
    },
    new Recipe
    {
        Id = 13,
        Title = "Protein Pancakes",
        Description = "Protein-rich pancakes topped with berries.",
        Calories = 360,
        IsHealthy = true,
        Img = ""
    },
    new Recipe
    {
        Id = 14,
        Title = "Chicken Alfredo",
        Description = "Pasta with creamy Alfredo sauce and chicken.",
        Calories = 720,
        IsHealthy = false,
        Img = ""
    },
    new Recipe
    {
        Id = 15,
        Title = "Tuna Salad",
        Description = "Tuna mixed with light mayo and vegetables.",
        Calories = 310,
        IsHealthy = true,
        Img = ""
    },
    new Recipe
    {
        Id = 16,
        Title = "Vegetable Soup",
        Description = "Light soup with seasonal vegetables.",
        Calories = 180,
        IsHealthy = true,
        Img = ""
    },
    new Recipe
    {
        Id = 17,
        Title = "BBQ Chicken Wings",
        Description = "Oven-baked chicken wings with BBQ sauce.",
        Calories = 600,
        IsHealthy = false,
        Img = ""
    },
    new Recipe
    {
        Id = 18,
        Title = "Shrimp Pasta",
        Description = "Pasta with shrimp, garlic, and olive oil.",
        Calories = 520,
        IsHealthy = false,
        Img = ""
    },
    new Recipe
    {
        Id = 19,
        Title = "Fruit Salad",
        Description = "Mixed fresh fruits with citrus dressing.",
        Calories = 200,
        IsHealthy = true,
        Img = ""
    },
    new Recipe
    {
        Id = 20,
        Title = "Dark Chocolate Oats",
        Description = "Oatmeal with dark chocolate and nuts.",
        Calories = 390,
        IsHealthy = true,
        Img = ""
    },
    new Recipe
    {
        Id = 21,
        Title = "Baked Sweet Potatoes",
        Description = "Oven-baked sweet potatoes with olive oil and herbs.",
        Calories = 260,
        IsHealthy = true,
        Img = ""
    }
            );
        }
    }
}
