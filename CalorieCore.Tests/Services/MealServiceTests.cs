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
            var userId = "user-1";

            db.UserAccounts.Add(new UserAccount { Id = 1, IdentityUserId = userId });
            await db.SaveChangesAsync();

            var meal = new Meal { Name = "Egg Sandwich", Calories = 350 };

            // Act
            await service.CreateMealAsync(meal, userId);

            // Assert
            var savedMeal = await db.Meals.FirstOrDefaultAsync();
            Assert.NotNull(savedMeal);
            Assert.Equal(350, savedMeal.Calories);
            Assert.Equal(1, savedMeal.UserAccountId);
        }

        [Fact]
        public async Task AddMealFromRecipeAsync_ShouldWork()
        {
            var db = GetDbContext();
            var service = new MealService(db);

            var user = new UserAccount { IdentityUserId = "user-1" };
            var recipe = new Recipe { Title = "Pasta", Calories = 600, Description = "Valid description..." };

            db.UserAccounts.Add(user);
            db.Recipes.Add(recipe);
            await db.SaveChangesAsync();

            var result = await service.AddMealFromRecipeAsync(recipe.Id, "user-1");

            Assert.True(result);
        }

        [Fact]
        public async Task DeleteMealAsync_ShouldReturnFalse_IfMealNotFound()
        {
            var db = GetDbContext();
            var service = new MealService(db);

            // Act
            var result = await service.DeleteMealAsync(999, "any-user");

            // Assert
            Assert.False(result);
        }
    }
}