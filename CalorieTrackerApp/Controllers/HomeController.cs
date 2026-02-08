using CalorieTrackerApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using CalorieTrackerApp.Data;

namespace CalorieTrackerApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Landing()
        {
            return View();
        }

        public async Task<IActionResult> Index()
        {
            var username = HttpContext.Session.GetString("Username");

            if (string.IsNullOrEmpty(username))
                return RedirectToAction("Landing");

            var user = await _context.UserAccounts
                .FirstOrDefaultAsync(u => u.Username == username);

            if (user == null)
                return RedirectToAction("Landing");

            var today = DateTime.Today;

            var meals = await _context.Meals
                .Where(m => m.UserAccountId == user.Id && m.Date.Date == today)
                .SumAsync(m => m.Calories);

            var burned = await _context.Activities
                .Where(a => a.UserAccountId == user.Id && a.Date.Date == today)
                .SumAsync(a => a.CaloriesBurned);

            int remaining = user.DailyCalorieGoal - meals + burned;

            ViewBag.Goal = user.DailyCalorieGoal;
            ViewBag.Remaining = remaining;
            ViewBag.Consumed = meals;
            ViewBag.Burned = burned;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
