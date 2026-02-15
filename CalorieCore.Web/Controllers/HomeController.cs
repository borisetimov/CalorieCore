using System.Security.Claims;
using CalorieCore.Data;
using CalorieCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CalorieCore.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [AllowAnonymous]
        public IActionResult Landing()
        {
            return View();
        }

        public async Task<IActionResult> Index()
        {
            var identityUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var user = await _context.UserAccounts
                .FirstOrDefaultAsync(u => u.IdentityUserId == identityUserId);

            if (user == null)
                return RedirectToAction("Landing");

            var today = DateTime.Today;

            var consumed = await _context.Meals
                .Where(m => m.UserAccountId == user.Id && m.Date.Date == today)
                .SumAsync(m => m.Calories);

            var burned = await _context.Activities
                .Where(a => a.UserAccountId == user.Id && a.Date.Date == today)
                .SumAsync(a => a.CaloriesBurned);

            var remaining = user.DailyCalorieGoal - consumed + burned;

            ViewBag.Goal = user.DailyCalorieGoal;
            ViewBag.Consumed = consumed;
            ViewBag.Burned = burned;
            ViewBag.Remaining = remaining;

            return View();
        }

        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
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
