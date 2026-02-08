using CalorieTrackerApp.Data;
using CalorieTrackerApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CalorieTrackerApp.Controllers
{
    public class UserActivitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserActivitiesController(ApplicationDbContext context)
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

            var activities = await _context.Activities
                .Where(a => a.UserAccountId == user.Id)
                .OrderByDescending(a => a.Date)
                .ToListAsync();

            return View(activities);
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
        public async Task<IActionResult> Create([Bind("Name,CaloriesBurned")] UserActivity userActivity)
        {
            var user = await GetCurrentUserAsync();
            if (user == null)
                return RedirectToAction("Login", "Account");

            if (ModelState.IsValid)
            {
                userActivity.UserAccountId = user.Id;
                userActivity.Date = DateTime.Now;

                _context.Activities.Add(userActivity);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(userActivity);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var user = await GetCurrentUserAsync();
            if (user == null)
                return RedirectToAction("Login", "Account");

            var activity = await _context.Activities
                .FirstOrDefaultAsync(a => a.Id == id && a.UserAccountId == user.Id);

            if (activity == null) return NotFound();

            return View(activity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UserActivity updatedActivity)
        {
            if (id != updatedActivity.Id) return NotFound();

            var user = await GetCurrentUserAsync();
            if (user == null)
                return RedirectToAction("Login", "Account");

            if (!ModelState.IsValid)
                return View(updatedActivity);

            var activity = await _context.Activities
                .FirstOrDefaultAsync(a => a.Id == id && a.UserAccountId == user.Id);

            if (activity == null) return NotFound();

            activity.Name = updatedActivity.Name;
            activity.CaloriesBurned = updatedActivity.CaloriesBurned;
            activity.Date = updatedActivity.Date;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var user = await GetCurrentUserAsync();
            if (user == null)
                return RedirectToAction("Login", "Account");

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
            if (user == null)
                return RedirectToAction("Login", "Account");

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
