using System.Security.Claims;
using CalorieCore.Data;
using CalorieCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CalorieCore.Controllers
{
    [Authorize]
    public class UserActivitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserActivitiesController(ApplicationDbContext context)
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

            var activities = await _context.Activities
                .Where(a => a.UserAccountId == user.Id)
                .OrderByDescending(a => a.Date)
                .ToListAsync();

            return View(activities);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserActivity activity)
        {
            var user = await GetCurrentUserAsync();
            if (user == null) return Unauthorized();

            if (!ModelState.IsValid)
                return View(activity);

            activity.UserAccountId = user.Id;
            activity.Date = DateTime.Now;

            _context.Activities.Add(activity);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var user = await GetCurrentUserAsync();
            if (user == null) return Unauthorized();

            var activity = await _context.Activities
                .FirstOrDefaultAsync(a => a.Id == id && a.UserAccountId == user.Id);

            if (activity == null) return NotFound();

            return View(activity);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await GetCurrentUserAsync();
            if (user == null) return Unauthorized();

            var activity = await _context.Activities
                .FirstOrDefaultAsync(a => a.Id == id && a.UserAccountId == user.Id);

            if (activity != null)
            {
                _context.Activities.Remove(activity);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
