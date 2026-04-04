using CalorieCore.DataModels;
using CalorieCore.Services;
using CalorieCore.Tests.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CalorieCore.Tests
{
    public class IntegrationTests : TestBase
    {

        [Fact]
        public async Task FullUserJourney_IntegrationTest()
        {

            // Arrange 
            var db = GetDbContext();
            var weightService = new WeightService(db);
            var recipeService = new RecipeService(db);
            var mealService = new MealService(db);
            string userId = "user1";

            // 1. Act
            await weightService.LogWeightAsync(userId, 85.5);

            // 2. Act
            var (recipes, _) = await recipeService.GetPagedRecipesAsync(userId, "Oatmeal", 1, 10);
            var targetRecipe = recipes.First();

            // 3. Act
            var mealResult = await mealService.AddMealFromRecipeAsync(targetRecipe.Id, userId);

            // 4. Assert
            var user = await db.UserAccounts
                .Include(u => u.WeightLogs)
                .FirstAsync(u => u.IdentityUserId == userId);

            var meals = await mealService.GetMealsByWeekAsync(userId, 0);

            Assert.True(mealResult); // Ensure the meal creation succeeded
            Assert.Equal(85.5, user.Weight); // Ensure profile weight updated
            Assert.Single(user.WeightLogs); // Ensure a log entry was created
            Assert.Contains(meals, m => m.Name == targetRecipe.Title); // Ensure meal exists in logs
        }
    }
}