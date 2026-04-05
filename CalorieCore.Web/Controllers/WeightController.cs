using CalorieCore.Web.Controllers;
using CalorieCore.Services;
using CalorieCore.Web.ViewModels; // Add this to find your new ViewModel
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CalorieCore.Web.Controllers
{
    [Authorize]
    public class WeightController : Controller
    {
        private readonly IWeightService _weightService;

        public WeightController(IWeightService weightService)
        {
            _weightService = weightService;
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