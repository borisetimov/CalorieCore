using CalorieCore.DataModels;
using CalorieCore.Services;
using Xunit;
using Microsoft.EntityFrameworkCore;

namespace CalorieCore.Tests.Services
{
    public class MealServiceTests : TestBase
    {
        [Fact]
        public async Task CreateMealAsync_ShouldSaveToDatabase()
        {
            var db = GetDbContext();
            var service = new MealService(db);
            var userId = "user1";

            var meal = new Meal { Name = "Egg Sandwich", Calories = 350 };

            // Act
            await service.CreateMealAsync(meal, userId);

            // Assert
            var savedMeal = await db.Meals.FirstOrDefaultAsync(m => m.Name == "Egg Sandwich");
            Assert.NotNull(savedMeal);
            Assert.Equal(350, savedMeal.Calories);
        }

        [Fact]
        public async Task AddMealFromRecipeAsync_ShouldWork()
        {
            var db = GetDbContext();
            var service = new MealService(db);
            var userId = "user1";

            var recipe = new Recipe { Title = "Pasta", Calories = 600, Description = "Test Desc", Type = "Lunch", Ingredients = "Test", Instructions = "Test", Tags = "Test" };

            db.Recipes.Add(recipe);
            await db.SaveChangesAsync();

            var result = await service.AddMealFromRecipeAsync(recipe.Id, userId);

            Assert.True(result);
        }

        [Fact]
        public async Task DeleteMealAsync_ShouldReturnFalse_IfMealNotFound()
        {
            var db = GetDbContext();
            var service = new MealService(db);

            var result = await service.DeleteMealAsync(999, "user1");

            Assert.False(result);
        }

        [Fact]
        public async Task GetMealById_OtherUserMeal_ReturnsNull()
        {
            var db = GetDbContext();
            var service = new MealService(db);

            var otherUser = new UserAccount { IdentityUserId = "user2", Gender = "Female", Goal = "Maintain" };
            db.UserAccounts.Add(otherUser);
            await db.SaveChangesAsync();

            var meal = new Meal { UserAccountId = otherUser.Id, Name = "User2's Lunch", Calories = 500 };
            db.Meals.Add(meal);
            await db.SaveChangesAsync();

            var result = await service.GetMealByIdAsync(meal.Id, "user1");

            Assert.Null(result);
        }

        [Fact]
        public async Task AddMealFromRecipe_ValidRecipe_CreatesMeal()
        {
            var db = GetDbContext();
            var service = new MealService(db);

            var result = await service.AddMealFromRecipeAsync(1, "user1");

            var meal = await db.Meals.FirstOrDefaultAsync(m => m.Name == "Grilled Chicken Salad");

            Assert.True(result);
            Assert.NotNull(meal);
            Assert.Equal(350, meal.Calories);
        }
    }
}