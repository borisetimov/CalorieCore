using CalorieTrackerApp.Data;
using CalorieTrackerApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CalorieTrackerApp.Controllers
{
    public class MealsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MealsController(ApplicationDbContext context)
        {
            _context = context;
        }

        private async Task<UserAccount?> GetCurrentUserAsync()
        {
            var username = HttpContext.Session.GetString("Username");

            if (string.IsNullOrEmpty(username))
                return null;

            return await _context.UserAccounts
                .FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();
            if (user == null)
                return RedirectToAction("Login", "Account");

            var meals = await _context.Meals
                .Where(m => m.UserAccountId == user.Id)
                .OrderByDescending(m => m.Date)
                .ToListAsync();

            return View(meals);
        }

        public async Task<IActionResult> Create()
        {
            var user = await GetCurrentUserAsync();
            if (user == null)
                return RedirectToAction("Login", "Account");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Calories")] Meal meal)
        {
            var user = await GetCurrentUserAsync();
            if (user == null)
                return RedirectToAction("Login", "Account");

            if (ModelState.IsValid)
            {
                meal.UserAccountId = user.Id;
                meal.Date = DateTime.Now;

                _context.Meals.Add(meal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(meal);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var user = await GetCurrentUserAsync();
            if (user == null)
                return RedirectToAction("Login", "Account");

            var meal = await _context.Meals
                .FirstOrDefaultAsync(m => m.Id == id && m.UserAccountId == user.Id);

            if (meal == null) return NotFound();

            return View(meal);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Meal updatedMeal)
        {
            var user = await GetCurrentUserAsync();
            if (user == null)
                return RedirectToAction("Login", "Account");

            if (id != updatedMeal.Id) return NotFound();

            if (!ModelState.IsValid)
                return View(updatedMeal);

            var meal = await _context.Meals
                .FirstOrDefaultAsync(m => m.Id == id && m.UserAccountId == user.Id);

            if (meal == null) return NotFound();

            meal.Name = updatedMeal.Name;
            meal.Calories = updatedMeal.Calories;
            meal.Date = updatedMeal.Date;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var user = await GetCurrentUserAsync();
            if (user == null)
                return RedirectToAction("Login", "Account");

            var meal = await _context.Meals
                .FirstOrDefaultAsync(m => m.Id == id && m.UserAccountId == user.Id);

            if (meal == null) return NotFound();

            return View(meal);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await GetCurrentUserAsync();
            if (user == null)
                return RedirectToAction("Login", "Account");

            var meal = await _context.Meals
                .FirstOrDefaultAsync(m => m.Id == id && m.UserAccountId == user.Id);

            if (meal != null)
            {
                _context.Meals.Remove(meal);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> AddFromRecipe(int recipeId)
        {
            var user = await GetCurrentUserAsync();
            if (user == null)
                return RedirectToAction("Login", "Account");

            var recipe = await _context.Recipes.FindAsync(recipeId);
            if (recipe == null) return NotFound();

            var meal = new Meal
            {
                Name = recipe.Title,
                Calories = recipe.Calories,
                UserAccountId = user.Id,
                Date = DateTime.Now
            };

            _context.Meals.Add(meal);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
