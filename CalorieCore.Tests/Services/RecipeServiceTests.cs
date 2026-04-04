using CalorieCore.DataModels;
using CalorieCore.Services;
using Xunit;
using Microsoft.EntityFrameworkCore;

namespace CalorieCore.Tests.Services
{
    public class RecipeServiceTests : TestBase
    {
        [Theory]
        [InlineData("Grilled Chicken Salad", 1)] // Matches exactly 1 from your Seed Data
        [InlineData("Oatmeal", 3)]              // Matches Oatmeal (2), Protein Oat (14), Baked Oatmeal (38)
        [InlineData("ThisDoesNotExist", 0)]
        public async Task GetPagedRecipes_SearchLogicTests(string search, int expected)
        {
            var db = GetDbContext(); // This now contains 52 recipes automatically
            var service = new RecipeService(db);

            var (recipes, _) = await service.GetPagedRecipesAsync("user1", search, 1, 100);

            Assert.Equal(expected, recipes.Count());
        }

        [Fact]
        public async Task GetRecipeById_ShouldReturnCorrectRecipe()
        {
            var db = GetDbContext();
            var service = new RecipeService(db);

            var recipe = new Recipe { Title = "FindMe", Calories = 500, IsGlobal = true, Description = "Valid description..." };
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
            var recipe = new Recipe { Title = "Fav", IsFavorite = false, Description = "Valid description..." };
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

            // Create a private recipe for user1
            var recipe = new Recipe { Title = "My Secret Cake", UserAccountId = 1, IsGlobal = false };
            db.Recipes.Add(recipe);
            await db.SaveChangesAsync();

            var result = await service.DeleteRecipeAsync(recipe.Id, "user1");

            Assert.True(result);
        }
    }
}