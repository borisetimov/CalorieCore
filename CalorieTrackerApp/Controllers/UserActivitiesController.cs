using CalorieTrackerApp.Data;
using CalorieTrackerApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public async Task<IActionResult> Index()
        {
            var username = HttpContext.Session.GetString("Username");

            var activities = _context.Activities
                .Where(a => a.Username == username)
                .OrderByDescending(a => a.Date)
                .ToList();

            return View(activities);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserActivity userActivity)
        {
            if (ModelState.IsValid)
            {
                userActivity.Username = HttpContext.Session.GetString("Username")!;
                userActivity.Date = DateTime.Now;

                _context.Activities.Add(userActivity);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(userActivity);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var userActivity = await _context.Activities.FindAsync(id);
            if (userActivity == null)
                return NotFound();

            return View(userActivity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UserActivity userActivity)
        {
            if (id != userActivity.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(userActivity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }   
            return View(userActivity);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var activity = await _context.Activities
                .FirstOrDefaultAsync(m => m.Id == id);

            if (activity == null) return NotFound();

            return View(activity);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activity = await _context.Activities.FindAsync(id);
            _context.Activities.Remove(activity!);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}