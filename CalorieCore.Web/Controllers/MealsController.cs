using CalorieCore.DataModels;
using CalorieCore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CalorieCore.Web.Controllers
{
    [Authorize]
    public class MealsController : Controller
    {
        private readonly IMealService _mealService;

        public MealsController(IMealService mealService)
        {
            _mealService = mealService;
        }

        private string CurrentUserId => User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        public async Task<IActionResult> Index(int offset = 0)
        {
            var meals = await _mealService.GetMealsByWeekAsync(CurrentUserId, offset);
            ViewBag.CurrentWeekOffset = offset;
            return View(meals);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Meal meal)
        {
            if (!ModelState.IsValid) return View(meal);
            await _mealService.CreateMealAsync(meal, CurrentUserId);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var meal = await _mealService.GetMealByIdAsync(id, CurrentUserId);
            if (meal == null) return NotFound();
            return View(meal);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Meal updatedMeal)
        {
            var success = await _mealService.UpdateMealAsync(id, updatedMeal, CurrentUserId);
            if (!success) return NotFound();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var meal = await _mealService.GetMealByIdAsync(id, CurrentUserId);
            if (meal == null) return NotFound();
            return View(meal);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _mealService.DeleteMealAsync(id, CurrentUserId);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddFromRecipe(int recipeId)
        {
            var success = await _mealService.AddMealFromRecipeAsync(recipeId, CurrentUserId);
            if (!success) return NotFound();
            return RedirectToAction(nameof(Index));
        }
    }
}