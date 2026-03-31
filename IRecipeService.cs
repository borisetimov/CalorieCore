using CalorieCore.DataModels;

namespace CalorieCore.Services.Contracts
{
    public interface IRecipeService
    {
        Task<IEnumerable<Recipe>> GetAllRecipesAsync(string userId);
        Task<Recipe?> GetRecipeByIdAsync(int id, string userId);
        Task CreateRecipeAsync(Recipe recipe, string userId);
        Task<bool> UpdateRecipeAsync(Recipe recipe, string userId);
        Task<bool> DeleteRecipeAsync(int id, string userId);
        Task<bool> ToggleFavoriteAsync(int recipeId);
    }
}