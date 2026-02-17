using System.Security.Claims;
using CalorieCore.Data.Migrations;
using CalorieCore.DataModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CalorieCore.Web.Controllers
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

        public async Task<IActionResult> Index(int offset = 0)
        {
            var user = await GetCurrentUserAsync();
            if (user == null) return Unauthorized();

            DayOfWeek firstDayOfWeek = DayOfWeek.Monday;
            DateTime baseDate = DateTime.Today.AddDays(offset * 7);
            int diff = (7 + (baseDate.DayOfWeek - firstDayOfWeek)) % 7;
            DateTime startOfWeek = baseDate.AddDays(-1 * diff).Date;
            DateTime endOfWeek = startOfWeek.AddDays(7);

            var activities = await _context.Activities
                .Where(a => a.UserAccountId == user.Id && a.Date >= startOfWeek && a.Date < endOfWeek)
                .OrderByDescending(a => a.Date)
                .ToListAsync();

            ViewBag.CurrentWeekOffset = offset;
            return View(activities);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserActivity activity)
        {
            var user = await GetCurrentUserAsync();
            if (user == null) return Unauthorized();

            activity.UserAccountId = user.Id;
            activity.Date = DateTime.Now;

            _context.Activities.Add(activity);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UserActivity updatedActivity)
        {
            var user = await GetCurrentUserAsync();
            if (user == null) return Unauthorized();

            var activity = await _context.Activities
                .FirstOrDefaultAsync(a => a.Id == id && a.UserAccountId == user.Id);

            if (activity == null) return NotFound();

            activity.Name = updatedActivity.Name;
            activity.CaloriesBurned = updatedActivity.CaloriesBurned;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
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