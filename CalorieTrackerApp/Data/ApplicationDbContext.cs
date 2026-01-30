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
                  Title = "Caesar Salad",
                  Calories = 350,
                  Type = "Salad",
                  Tags = "Easy to make, Quick, Low-calorie",
                  Ingredients = "Romaine lettuce, Parmesan, Croutons, Caesar dressing",
                  Instructions = "1. Chop lettuce. 2. Add dressing and croutons. 3. Sprinkle parmesan and serve.",
                  Img = "/images/caesar_salad.png"
              },
    new Recipe
    {
        Id = 2,
        Title = "Chocolate Cake",
        Calories = 550,
        Type = "Dessert",
        Tags = "Sweet, High-calorie, Easy to make",
        Ingredients = "Flour, Sugar, Cocoa powder, Eggs, Butter",
        Instructions = "1. Mix ingredients. 2. Bake at 180°C for 30 mins. 3. Cool and serve.",
        Img = "/images/chocolate_cake.png"
    }
            );
        }
    }
}
