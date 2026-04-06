using CalorieCore.Data; 
using CalorieCore.Data.Migrations;
using CalorieCore.Services;
using CalorieCore.Web.Controllers;
using CalorieCore.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CalorieCore.Web.Controllers
{
    [Authorize]
    public class WeightController : Controller
    {
        private readonly IWeightService _weightService;
        private readonly ApplicationDbContext _context; 

        public WeightController(IWeightService weightService, ApplicationDbContext context)
        {
            _weightService = weightService;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userAccount = await _weightService.GetUserAccountWithLogsAsync(userId);

            if (userAccount == null) return RedirectToAction("Landing", "Home");

            var model = new WeightViewModel
            {
                Logs = userAccount.WeightLogs.OrderByDescending(l => l.DateRecorded).ToList(),
                Height = userAccount.Height
            };

            if (userAccount.Height > 0)
            {
                model.CurrentWeight = model.Logs.Any()
                    ? model.Logs.First().Weight
                    : userAccount.Weight;

                model.Status = WeightCalculator.Analyze(
                    model.CurrentWeight,
                    userAccount.Height,
                    userAccount.Age
                );
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LogWeight(double weight)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await _weightService.LogWeightAsync(userId, weight);

            var userAccount = await _context.UserAccounts
                .FirstOrDefaultAsync(u => u.IdentityUserId == userId);

            if (userAccount != null)
            {
                userAccount.Weight = weight;

                var bmr = (10 * userAccount.Weight) + (6.25 * userAccount.Height) - (5 * userAccount.Age);
                bmr = (userAccount.Gender == "Male") ? bmr + 5 : bmr - 161;
                double tdee = bmr * userAccount.ActivityMultiplier;

                double targetCalories = userAccount.Goal switch
                {
                    "Lose" => tdee - 500,
                    "Gain" => tdee + 500,
                    _ => tdee
                };

                userAccount.DailyCalorieGoal = (int)Math.Round(targetCalories);
                userAccount.DailyProteinGoal = (int)((targetCalories * 0.30) / 4);
                userAccount.DailyCarbGoal = (int)((targetCalories * 0.45) / 4);
                userAccount.DailyFatGoal = (int)((targetCalories * 0.25) / 9);

                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteLog(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var success = await _weightService.DeleteLogAsync(id, userId);

            if (!success) return Unauthorized();

            return RedirectToAction(nameof(Index));
        }
    }
}