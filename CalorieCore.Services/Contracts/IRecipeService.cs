using CalorieCore.DataModels;

namespace CalorieCore.Services
{
    public interface IRecipeService
    {
        Task<(IEnumerable<Recipe> Recipes, int TotalPages)> GetPagedRecipesAsync(string userId, string? searchString, int page, int pageSize);
        Task<Recipe?> GetRecipeByIdAsync(int id, string userId);
        Task<bool> CreateRecipeAsync(Recipe recipe, string userId);
        Task<bool> UpdateRecipeAsync(int id, Recipe updatedRecipe, string userId);
        Task<bool> DeleteRecipeAsync(int id, string userId);
        Task<bool> ToggleFavoriteAsync(int id, string userId);
    }
}