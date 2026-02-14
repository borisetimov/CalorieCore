using System.Security.Claims;
using CalorieTrackerApp.Data;
using CalorieTrackerApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CalorieTrackerApp.Controllers
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
    }
}
