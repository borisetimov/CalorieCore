using CalorieCore.Data.Migrations;
using CalorieCore.DataModels;
using Microsoft.EntityFrameworkCore;

namespace CalorieCore.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly ApplicationDbContext _context;

        public RecipeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<Recipe> Recipes, int TotalPages)> GetPagedRecipesAsync(string userId, string? searchString, int page, int pageSize)
        {
            var query = _context.Recipes
                .Include(r => r.UserAccount)
                .Where(r => r.IsGlobal || (r.UserAccount != null && r.UserAccount.IdentityUserId == userId));

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(r => r.Title.Contains(searchString) || r.Tags.Contains(searchString));
            }

            int totalItems = await query.CountAsync();
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            var recipes = await query
                .OrderBy(r => r.Title)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (recipes, totalPages);
        }

        public async Task<Recipe?> GetRecipeByIdAsync(int id, string userId)
        {
            return await _context.Recipes
                .Include(r => r.UserAccount)
                .FirstOrDefaultAsync(r => r.Id == id &&
                    (r.IsGlobal || (r.UserAccount != null && r.UserAccount.IdentityUserId == userId)));
        }

        public async Task<bool> CreateRecipeAsync(Recipe recipe, string userId)
        {
            var userAccount = await _context.UserAccounts.FirstOrDefaultAsync(u => u.IdentityUserId == userId);
            if (userAccount == null) return false;

            recipe.UserAccountId = userAccount.Id;
            recipe.IsGlobal = false;
            recipe.IsFavorite = false;

            _context.Add(recipe);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateRecipeAsync(int id, Recipe updatedRecipe, string userId)
        {
            var recipe = await _context.Recipes
                .Include(r => r.UserAccount)
                .FirstOrDefaultAsync(r => r.Id == id);

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

        public async Task<bool> ToggleFavoriteAsync(int id, string userId)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null) return false;

            recipe.IsFavorite = !recipe.IsFavorite;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}