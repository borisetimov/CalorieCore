using CalorieCore.Web.Controllers;
using CalorieCore.Services;
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
            var chartData = await _weightService.GetChartDataAsync(userId);

            if (chartData == null) return RedirectToAction("Landing", "Home");

            return View(chartData);
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