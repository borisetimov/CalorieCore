using CalorieCore.Data;
using CalorieCore.DataModels;
using CalorieCore.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace CalorieCore.Services.Implementations
{
    public class RecipeService : IRecipeService
    {
        private readonly ApplicationDbContext _context;

        public RecipeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Recipe>> GetAllRecipesAsync(string userId)
        {
            return await _context.Recipes
                .Include(r => r.UserAccount)
                .Where(r => r.IsGlobal || (r.UserAccount != null && r.UserAccount.IdentityUserId == userId))
                .ToListAsync();
        }

        public async Task<Recipe?> GetRecipeByIdAsync(int id, string userId)
        {
            return await _context.Recipes
                .Include(r => r.UserAccount)
                .FirstOrDefaultAsync(r => r.Id == id &&
                    (r.IsGlobal || (r.UserAccount != null && r.UserAccount.IdentityUserId == userId)));
        }

        public async Task CreateRecipeAsync(Recipe recipe, string userId)
        {
            var userAccount = await _context.UserAccounts
                .FirstOrDefaultAsync(u => u.IdentityUserId == userId);

            if (userAccount != null)
            {
                recipe.UserAccountId = userAccount.Id;
                recipe.IsGlobal = false;
                recipe.IsFavorite = false;
                _context.Recipes.Add(recipe);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> UpdateRecipeAsync(Recipe updatedRecipe, string userId)
        {
            var recipe = await _context.Recipes
                .Include(r => r.UserAccount)
                .FirstOrDefaultAsync(r => r.Id == updatedRecipe.Id);

            if (recipe == null || recipe.IsGlobal || recipe.UserAccount?.IdentityUserId != userId)
                return false;

            recipe.Title = updatedRecipe.Title;
            recipe.Description = updatedRecipe.Description;
            recipe.Calories = updatedRecipe.Calories;
            recipe.Type = updatedRecipe.Type;
            recipe.Tags = updatedRecipe.Tags;
            recipe.Ingredients = updatedRecipe.Ingredients;
            recipe.Instructions = updatedRecipe.Instructions;
            recipe.Difficulty = updatedRecipe.Difficulty;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteRecipeAsync(int id, string userId)
        {
            var recipe = await _context.Recipes
                .Include(r => r.UserAccount)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (recipe == null || recipe.IsGlobal || recipe.UserAccount?.IdentityUserId != userId)
                return false;

            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ToggleFavoriteAsync(int recipeId)
        {
            var recipe = await _context.Recipes.FindAsync(recipeId);
            if (recipe == null) return false;

            recipe.IsFavorite = !recipe.IsFavorite;
            await _context.SaveChangesAsync();
            return recipe.IsFavorite;
        }
    }
}