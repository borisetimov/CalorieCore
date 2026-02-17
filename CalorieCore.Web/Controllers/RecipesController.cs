using CalorieCore.Data.Migrations;
using CalorieCore.DataModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CalorieCore.Web.Controllers
{
    [Authorize]
    public class RecipesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecipesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var recipes = await _context.Recipes
                .Include(r => r.UserAccount)
                .Where(r => r.IsGlobal ||
                    (r.UserAccount != null && r.UserAccount.IdentityUserId == userId))
                .ToListAsync();

            return View(recipes);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var recipe = await _context.Recipes
                .Include(r => r.UserAccount)
                .FirstOrDefaultAsync(r => r.Id == id &&
                    (r.IsGlobal || (r.UserAccount != null && r.UserAccount.IdentityUserId == userId)));

            if (recipe == null) return NotFound();

            return View(recipe);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Recipe recipe)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userAccount = await _context.UserAccounts
                .FirstOrDefaultAsync(u => u.IdentityUserId == userId);

            if (userAccount == null) return Unauthorized();

            if (!ModelState.IsValid) return View(recipe);

            recipe.UserAccountId = userAccount.Id;
            recipe.IsGlobal = false;
            recipe.IsFavorite = false;

            _context.Add(recipe);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var recipe = await _context.Recipes
                .Include(r => r.UserAccount)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (recipe == null) return NotFound();

            if (recipe.IsGlobal || recipe.UserAccount?.IdentityUserId != userId)
                return Forbid();

            return View(recipe);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Recipe updatedRecipe)
        {
            if (id != updatedRecipe.Id) return NotFound();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var recipe = await _context.Recipes
                .Include(r => r.UserAccount)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (recipe == null) return NotFound();

            if (recipe.IsGlobal || recipe.UserAccount?.IdentityUserId != userId)
                return Forbid();

            if (!ModelState.IsValid) return View(updatedRecipe);

            recipe.Title = updatedRecipe.Title;
            recipe.Description = updatedRecipe.Description;
            recipe.Calories = updatedRecipe.Calories;
            recipe.Type = updatedRecipe.Type;
            recipe.Tags = updatedRecipe.Tags;
            recipe.Ingredients = updatedRecipe.Ingredients;
            recipe.Instructions = updatedRecipe.Instructions;
            recipe.Difficulty = updatedRecipe.Difficulty;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var recipe = await _context.Recipes
                .Include(r => r.UserAccount)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (recipe == null) return NotFound();

            if (recipe.IsGlobal || recipe.UserAccount?.IdentityUserId != userId)
                return Forbid();


            return PartialView("_DeletePartial", recipe);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var recipe = await _context.Recipes
                .Include(r => r.UserAccount)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (recipe == null) return NotFound();

            if (recipe.IsGlobal || recipe.UserAccount?.IdentityUserId != userId)
                return Forbid();

            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}