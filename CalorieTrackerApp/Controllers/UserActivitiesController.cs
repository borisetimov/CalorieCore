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

        // GET: UserActivities
        public async Task<IActionResult> Index()
        {
            var activities = await _context.Activities.ToListAsync();
            return View(activities);
        }

        // GET: UserActivities/Create
        public IActionResult Create()
        {
            ViewBag.UserProfiles = new SelectList(_context.UserProfiles, "Id", "Name");
            return View();
        }

        // POST: UserActivities/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserActivity userActivity)
        {
            if (ModelState.IsValid)
            {
                _context.Activities.Add(userActivity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.UserProfiles = new SelectList(_context.UserProfiles, "Id", "Name", userActivity.UserProfileId);
            return View(userActivity);
        }

        // GET: UserActivities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var activity = await _context.Activities.FindAsync(id);
            if (activity == null) return NotFound();

            return View(activity);
        }

        // POST: UserActivities/Edit/5
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

        // GET: UserActivities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var activity = await _context.Activities
                .FirstOrDefaultAsync(m => m.Id == id);

            if (activity == null) return NotFound();

            return View(activity);
        }

        // POST: UserActivities/Delete/5
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