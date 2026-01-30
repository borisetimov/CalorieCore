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

        public async Task<IActionResult> Index()
        {
            var username = HttpContext.Session.GetString("Username");
            var meals = await _context.Meals
                .Where(m => m.Username == username)
                .OrderByDescending(m => m.Date)
                .ToListAsync();
            return View(meals);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Meal meal)
        {
            if (ModelState.IsValid)
            {
                meal.Username = HttpContext.Session.GetString("Username");
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

            var meal = await _context.Meals.FindAsync(id);
            if (meal == null) return NotFound();

            return View(meal);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Meal updatedMeal)
        {
            if (id != updatedMeal.Id) return NotFound();

            if (!ModelState.IsValid)
                return View(updatedMeal);
            var meal = await _context.Meals.FindAsync(id);
            if (meal == null) return NotFound();

            meal.Name = updatedMeal.Name;
            meal.Calories = updatedMeal.Calories;
            meal.Date = updatedMeal.Date;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Meals.Any(m => m.Id == id))
                    return NotFound();
                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var meal = await _context.Meals
                .FirstOrDefaultAsync(m => m.Id == id);

            if (meal == null) return NotFound();

            return View(meal);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meal = await _context.Meals.FindAsync(id);
            if (meal != null)
            {
                _context.Meals.Remove(meal);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
