using CalorieCore.DataModels;
using CalorieCore.Data.Migrations;
using Microsoft.EntityFrameworkCore;

namespace CalorieCore.Services
{
    public class MealService : IMealService
    {
        private readonly ApplicationDbContext _context;

        public MealService(ApplicationDbContext context)
        {
            _context = context;
        }

        private async Task<int?> GetUserAccountIdAsync(string identityUserId)
        {
            var user = await _context.UserAccounts
                .FirstOrDefaultAsync(u => u.IdentityUserId == identityUserId);
            return user?.Id;
        }

        public async Task<List<Meal>> GetMealsByWeekAsync(string identityUserId, int offset)
        {
            var userAccountId = await GetUserAccountIdAsync(identityUserId);
            if (userAccountId == null) return new List<Meal>();

            DayOfWeek firstDayOfWeek = DayOfWeek.Monday;
            DateTime baseDate = DateTime.Today.AddDays(offset * 7);
            int diff = (7 + (baseDate.DayOfWeek - firstDayOfWeek)) % 7;
            DateTime startOfWeek = baseDate.AddDays(-1 * diff).Date;
            DateTime endOfWeek = startOfWeek.AddDays(7);

            return await _context.Meals
                .Where(m => m.UserAccountId == userAccountId && m.Date >= startOfWeek && m.Date < endOfWeek)
                .OrderByDescending(m => m.Date)
                .ToListAsync();
        }

        public async Task<Meal?> GetMealByIdAsync(int id, string identityUserId)
        {
            var userAccountId = await GetUserAccountIdAsync(identityUserId);
            return await _context.Meals
                .FirstOrDefaultAsync(m => m.Id == id && m.UserAccountId == userAccountId);
        }

        public async Task CreateMealAsync(Meal meal, string identityUserId)
        {
            var userAccountId = await GetUserAccountIdAsync(identityUserId);
            if (userAccountId != null)
            {
                meal.UserAccountId = userAccountId.Value;
                meal.Date = DateTime.Now;
                _context.Meals.Add(meal);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> UpdateMealAsync(int id, Meal updatedMeal, string identityUserId)
        {
            var meal = await GetMealByIdAsync(id, identityUserId);
            if (meal == null) return false;

            meal.Name = updatedMeal.Name;
            meal.Calories = updatedMeal.Calories;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteMealAsync(int id, string identityUserId)
        {
            var meal = await GetMealByIdAsync(id, identityUserId);
            if (meal == null) return false;

            _context.Meals.Remove(meal);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddMealFromRecipeAsync(int recipeId, string identityUserId)
        {
            var userAccountId = await GetUserAccountIdAsync(identityUserId);
            var recipe = await _context.Recipes.FindAsync(recipeId);

            if (userAccountId == null || recipe == null) return false;

            var meal = new Meal
            {
                UserAccountId = userAccountId.Value,
                Name = recipe.Title,
                Calories = recipe.Calories,
                Date = DateTime.Now
            };

            _context.Meals.Add(meal);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}