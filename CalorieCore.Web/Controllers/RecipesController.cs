using CalorieCore.DataModels;
using CalorieCore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CalorieCore.Web.Controllers
{
    [Authorize]
    public class RecipesController : Controller
    {
        private readonly IRecipeService _recipeService;

        public RecipesController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        private string CurrentUserId => User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        public async Task<IActionResult> Index(string searchString, int? page)
        {
            int pageSize = 9;
            int pageNumber = page ?? 1;

            var (recipes, totalPages) = await _recipeService.GetPagedRecipesAsync(CurrentUserId, searchString, pageNumber, pageSize);

            ViewBag.CurrentPage = pageNumber;
            ViewBag.TotalPages = totalPages;
            ViewBag.SearchString = searchString;

            return View(recipes);
        }

        public async Task<IActionResult> Details(int id)
        {
            var recipe = await _recipeService.GetRecipeByIdAsync(id, CurrentUserId);
            if (recipe == null) return NotFound();
            return View(recipe);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Recipe recipe)
        {
            if (!ModelState.IsValid) return View(recipe);

            var success = await _recipeService.CreateRecipeAsync(recipe, CurrentUserId);
            if (!success) return Unauthorized();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var recipe = await _recipeService.GetRecipeByIdAsync(id, CurrentUserId);
            if (recipe == null) return NotFound();

            // Re-check ownership for Edit specifically (since Details allows Global)
            if (recipe.IsGlobal || recipe.UserAccount?.IdentityUserId != CurrentUserId)
                return Forbid();

            return View(recipe);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Recipe updatedRecipe)
        {
            if (!ModelState.IsValid) return View(updatedRecipe);

            var success = await _recipeService.UpdateRecipeAsync(id, updatedRecipe, CurrentUserId);
            if (!success) return Forbid();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var recipe = await _recipeService.GetRecipeByIdAsync(id, CurrentUserId);
            if (recipe == null || recipe.IsGlobal || recipe.UserAccount?.IdentityUserId != CurrentUserId)
                return Forbid();

            return PartialView("_DeletePartial", recipe);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var success = await _recipeService.DeleteRecipeAsync(id, CurrentUserId);
            if (!success) return Forbid();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> ToggleFavorite(int id)
        {
            var success = await _recipeService.ToggleFavoriteAsync(id, CurrentUserId);
            if (!success) return NotFound();

            return Json(new { success = true });
        }
    }
}