using CalorieCore.Data.Migrations;
using CalorieCore.DataModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CalorieCore.Web.Controllers
{
    [Authorize]
    public class WeightController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WeightController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userAccount = await _context.UserAccounts
                .Include(u => u.WeightLogs)
                .FirstOrDefaultAsync(u => u.IdentityUserId == userId);

            if (userAccount == null) return RedirectToAction("Landing", "Home");

            var chartData = userAccount.WeightLogs
                .OrderByDescending(w => w.DateRecorded)
                .Take(7)
                .OrderBy(w => w.DateRecorded)
                .ToList();

            return View(chartData);
        }

        [HttpPost]
        public async Task<IActionResult> LogWeight(double weight)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userAccount = await _context.UserAccounts
                .FirstOrDefaultAsync(u => u.IdentityUserId == userId);

            if (userAccount != null && weight > 0)
            {
                var entry = new WeightLog
                {
                    Weight = weight,
                    DateRecorded = DateTime.Now,
                    UserAccountId = userAccount.Id
                };

                _context.WeightLogs.Add(entry);

                userAccount.Weight = weight;

                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}