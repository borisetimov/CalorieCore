using System.Security.Claims;
using CalorieCore.Data;
using CalorieCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace CalorieCore.Controllers
{
    [Authorize]
    public class MealsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MealsController(ApplicationDbContext context)
        {
            _context = context;
        }

        private async Task<UserAccount?> GetCurrentUserAsync()
        {
            var identityUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return await _context.UserAccounts
                .FirstOrDefaultAsync(u => u.IdentityUserId == identityUserId);
        }

        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();
            if (user == null) return Unauthorized();

            var meals = await _context.Meals
                .Where(m => m.UserAccountId == user.Id)
                .OrderByDescending(m => m.Date)
                .ToListAsync();

            return View(meals);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Meal meal)
        {
            var user = await GetCurrentUserAsync();
            if (user == null) return Unauthorized();

            if (!ModelState.IsValid)
                return View(meal);

            meal.UserAccountId = user.Id;
            meal.Date = DateTime.Now;

            _context.Meals.Add(meal);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var user = await GetCurrentUserAsync();
            if (user == null) return Unauthorized();

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
            if (user == null) return Unauthorized();

            var meal = await _context.Meals
                .FirstOrDefaultAsync(m => m.Id == id && m.UserAccountId == user.Id);

            if (meal == null) return NotFound();

            meal.Name = updatedMeal.Name;
            meal.Calories = updatedMeal.Calories;
            meal.Date = updatedMeal.Date;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var user = await GetCurrentUserAsync();
            if (user == null) return Unauthorized();

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
            if (user == null) return Unauthorized();

            var meal = await _context.Meals
                .FirstOrDefaultAsync(m => m.Id == id && m.UserAccountId == user.Id);

            if (meal != null)
            {
                _context.Meals.Remove(meal);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> AddFromRecipe(int recipeId)
        {
            var user = await GetCurrentUserAsync();
            if (user == null) return Unauthorized();

            var recipe = await _context.Recipes.FindAsync(recipeId);
            if (recipe == null) return NotFound();

            var meal = new Meal
            {
                UserAccountId = user.Id,
                Name = recipe.Title,
                Calories = recipe.Calories,
                Date = DateTime.Now
            };

            _context.Meals.Add(meal);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
