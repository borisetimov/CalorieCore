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

        // GET: Recipes
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Fetching all global recipes and recipes belonging to the logged-in user
            var recipes = await _context.Recipes
                .Include(r => r.UserAccount)
                .Where(r => r.IsGlobal ||
                    (r.UserAccount != null && r.UserAccount.IdentityUserId == userId))
                .ToListAsync();

            return View(recipes);
        }

        // GET: Recipes/Details/5
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

        // GET: Recipes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recipes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Recipe recipe)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userAccount = await _context.UserAccounts
                .FirstOrDefaultAsync(u => u.IdentityUserId == userId);

            if (userAccount == null) return Unauthorized();

            if (!ModelState.IsValid) return View(recipe);

            // Set default properties for a new user-created recipe
            recipe.UserAccountId = userAccount.Id;
            recipe.IsGlobal = false;
            recipe.IsFavorite = false;

            _context.Add(recipe);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Recipes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var recipe = await _context.Recipes
                .Include(r => r.UserAccount)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (recipe == null) return NotFound();

            // Guard: Cannot edit global recipes or recipes belonging to others
            if (recipe.IsGlobal || recipe.UserAccount?.IdentityUserId != userId)
                return Forbid();

            return View(recipe);
        }

        // POST: Recipes/Edit/5
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

            // Guard: Re-check permissions on POST
            if (recipe.IsGlobal || recipe.UserAccount?.IdentityUserId != userId)
                return Forbid();

            if (!ModelState.IsValid) return View(updatedRecipe);

            // Map updated values to existing entity
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

        // GET: Recipes/Delete/5 (Called by AJAX for the Modal)
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var recipe = await _context.Recipes
                .Include(r => r.UserAccount)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (recipe == null) return NotFound();

            // Guard: Prevent unauthorized deletion
            if (recipe.IsGlobal || recipe.UserAccount?.IdentityUserId != userId)
                return Forbid();

            // IMPORTANT: Returns a Partial View for the Modal pop-up
            return PartialView("_DeletePartial", recipe);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var recipe = await _context.Recipes
                .Include(r => r.UserAccount)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (recipe == null) return NotFound();

            // Guard: Prevent unauthorized deletion
            if (recipe.IsGlobal || recipe.UserAccount?.IdentityUserId != userId)
                return Forbid();

            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}