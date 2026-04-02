using CalorieCore.DataModels;

namespace CalorieCore.Services
{
    public interface IMealService
    {
        Task<List<Meal>> GetMealsByWeekAsync(string identityUserId, int offset);
        Task<Meal?> GetMealByIdAsync(int id, string identityUserId);
        Task CreateMealAsync(Meal meal, string identityUserId);
        Task<bool> UpdateMealAsync(int id, Meal updatedMeal, string identityUserId);
        Task<bool> DeleteMealAsync(int id, string identityUserId);
        Task<bool> AddMealFromRecipeAsync(int recipeId, string identityUserId);
    }
}