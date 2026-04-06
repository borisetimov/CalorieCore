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

        public async Task<IActionResult> Index(string searchString, int? myPage, int? globalPage)
        {
            int pageSize = 12;
            int myPageNum = myPage ?? 1;
            int globalPageNum = globalPage ?? 1;

            var (allRecipes, _) = await _recipeService.GetPagedRecipesAsync(CurrentUserId, searchString, 1, 999);

            var mySource = allRecipes
                .Where(r => !r.IsGlobal || r.IsFavorite)
                .OrderByDescending(r => r.Id)
                .ToList();

            var globalSource = allRecipes
                .Where(r => r.IsGlobal)
                .OrderBy(r => r.Title)
                .ToList();

            var myRecipesPaged = mySource.Skip((myPageNum - 1) * pageSize).Take(pageSize).ToList();
            var globalRecipesPaged = globalSource.Skip((globalPageNum - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.MyTotalPages = (int)Math.Ceiling((double)mySource.Count / pageSize);
            ViewBag.GlobalTotalPages = (int)Math.Ceiling((double)globalSource.Count / pageSize);
            ViewBag.MyCurrentPage = myPageNum;
            ViewBag.GlobalCurrentPage = globalPageNum;
            ViewBag.SearchString = searchString;
            ViewBag.GlobalRecipes = globalRecipesPaged;

            return View(myRecipesPaged);
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
            return success ? RedirectToAction(nameof(Index)) : Unauthorized();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var recipe = await _recipeService.GetRecipeByIdAsync(id, CurrentUserId);
            if (recipe == null || recipe.IsGlobal || recipe.UserAccount?.IdentityUserId != CurrentUserId) return Forbid();
            return View(recipe);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Recipe updatedRecipe)
        {
            if (!ModelState.IsValid) return View(updatedRecipe);
            var success = await _recipeService.UpdateRecipeAsync(id, updatedRecipe, CurrentUserId);
            return success ? RedirectToAction(nameof(Index)) : Forbid();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var recipe = await _recipeService.GetRecipeByIdAsync(id, CurrentUserId);
            if (recipe == null || recipe.IsGlobal || recipe.UserAccount?.IdentityUserId != CurrentUserId) return Forbid();
            return PartialView("_DeletePartial", recipe);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var success = await _recipeService.DeleteRecipeAsync(id, CurrentUserId);
            return success ? RedirectToAction(nameof(Index)) : Forbid();
        }

        [HttpPost]
        public async Task<IActionResult> ToggleFavorite(int id)
        {
            var success = await _recipeService.ToggleFavoriteAsync(id, CurrentUserId);
            return success ? Json(new { success = true }) : NotFound();
        }
    }
}