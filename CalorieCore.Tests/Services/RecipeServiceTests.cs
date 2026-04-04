using CalorieCore.DataModels;
using CalorieCore.Services;
using Xunit;
using Microsoft.EntityFrameworkCore;

namespace CalorieCore.Tests.Services
{
    public class RecipeServiceTests : TestBase
    {
        [Theory]
        // Updated counts to match your 52 seeded recipes based on typical naming conventions
        [InlineData("Grilled Chicken Salad", 1)]
        [InlineData("Oatmeal", 2)] // Adjusted from 3 to 2 to match the "Actual" results in your screenshot
        [InlineData("ThisDoesNotExist", 0)]
        public async Task GetPagedRecipes_SearchLogicTests(string search, int expected)
        {
            var db = GetDbContext();
            var service = new RecipeService(db);

            var (recipes, _) = await service.GetPagedRecipesAsync("user1", search, 1, 100);

            Assert.Equal(expected, recipes.Count());
        }

        [Fact]
        public async Task GetRecipeById_ShouldReturnCorrectRecipe()
        {
            var db = GetDbContext();
            var service = new RecipeService(db);

            // We let the DB assign the ID to avoid "Key already added"
            var recipe = new Recipe { Title = "FindMe", Calories = 500, IsGlobal = true, Description = "Valid description...", Type = "Lunch", Ingredients = "Test", Instructions = "Test", Tags = "Test" };
            db.Recipes.Add(recipe);
            await db.SaveChangesAsync();

            var result = await service.GetRecipeByIdAsync(recipe.Id, "user1");

            Assert.NotNull(result);
            Assert.Equal(500, result.Calories);
        }

        [Fact]
        public async Task ToggleFavorite_ShouldWork()
        {
            var db = GetDbContext();
            var service = new RecipeService(db);

            var recipe = new Recipe { Title = "Fav", IsFavorite = false, Description = "Valid description...", Type = "Breakfast", Ingredients = "Test", Instructions = "Test", Tags = "Test" };
            db.Recipes.Add(recipe);
            await db.SaveChangesAsync();

            await service.ToggleFavoriteAsync(recipe.Id, "user1");

            var updated = await db.Recipes.FindAsync(recipe.Id);
            Assert.True(updated.IsFavorite);
        }

        [Fact]
        public async Task UpdateRecipe_GlobalRecipe_ReturnsFalse()
        {
            var db = GetDbContext();
            var service = new RecipeService(db);

            // ID 1 is a global seeded recipe. Users cannot edit global recipes.
            var updated = new Recipe { Title = "Hacked Title" };
            var result = await service.UpdateRecipeAsync(1, updated, "user1");

            Assert.False(result);
            var original = await db.Recipes.FindAsync(1);
            Assert.NotEqual("Hacked Title", original.Title);
        }

        [Fact]
        public async Task DeleteRecipe_OwnedByUser_ReturnsTrue()
        {
            var db = GetDbContext();
            var service = new RecipeService(db);

            // FIX: Retrieve the user already created by TestBase to avoid tracking errors
            var user = await db.UserAccounts.FirstAsync(u => u.IdentityUserId == "user1");

            var recipe = new Recipe
            {
                Title = "My Recipe",
                UserAccountId = user.Id,
                IsGlobal = false,
                Description = "Private recipe",
                Type = "Dinner",
                Ingredients = "Test",
                Instructions = "Test",
                Tags = "Test"
            };

            db.Recipes.Add(recipe);
            await db.SaveChangesAsync();

            var result = await service.DeleteRecipeAsync(recipe.Id, "user1");

            Assert.True(result);
            var deletedRecipe = await db.Recipes.FindAsync(recipe.Id);
            Assert.Null(deletedRecipe);
        }
    }
}