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

        public IActionResult Index()
        {
            var username = HttpContext.Session.GetString("Username");

            if (username == null)
                return RedirectToAction("Landing");

            var user = _context.UserAccounts.First(u => u.Username == username);

            var meals = _context.Meals
                .Where(m => m.Username == username && m.Date.Date == DateTime.Today)
                .Sum(m => m.Calories);

            var burned = _context.Activities
                .Where(a => a.Date.Date == DateTime.Today)
                .Sum(a => a.CaloriesBurned);

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
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
