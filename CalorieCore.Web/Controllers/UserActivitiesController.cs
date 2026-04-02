using System.Security.Claims;
using CalorieCore.DataModels;
using CalorieCore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CalorieCore.Web.Controllers
{
    [Authorize]
    public class UserActivitiesController : Controller
    {
        private readonly IUserActivityService _activityService;

        public UserActivitiesController(IUserActivityService activityService)
        {
            _activityService = activityService;
        }

        private string CurrentUserId => User.FindFirstValue(ClaimTypes.NameIdentifier)!;

        public async Task<IActionResult> Index(int offset = 0)
        {
            var activities = await _activityService.GetActivitiesByWeekAsync(CurrentUserId, offset);
            ViewBag.CurrentWeekOffset = offset;
            return View(activities);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserActivity activity)
        {
            if (!ModelState.IsValid) return RedirectToAction(nameof(Index));

            await _activityService.CreateActivityAsync(activity, CurrentUserId);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UserActivity updatedActivity)
        {
            var success = await _activityService.UpdateActivityAsync(id, updatedActivity, CurrentUserId);
            if (!success) return NotFound();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var success = await _activityService.DeleteActivityAsync(id, CurrentUserId);
            return RedirectToAction(nameof(Index));
        }
    }
}