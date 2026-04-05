using CalorieCore.ViewModels;
using CalorieCore.Services;
using CalorieCore.Data.Migrations; // Ensure this points to your ApplicationDbContext location
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CalorieCore.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context; // Added DB context

        public AccountController(
            IAccountService accountService,
            UserManager<IdentityUser> userManager,
            ApplicationDbContext context)
        {
            _accountService = accountService;
            _userManager = userManager;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Settings()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return RedirectToAction("Login");

            var userAccount = await _context.UserAccounts
                .FirstOrDefaultAsync(u => u.IdentityUserId == user.Id);

            var model = new SettingsViewModel
            {
                Id = user.Id,
                Username = user.UserName ?? "",
                Email = user.Email ?? "",
                // Pulling all data now, including Age and Activity Level
                Height = userAccount?.Height ?? 0,
                Gender = userAccount?.Gender ?? "Male",
                Age = userAccount?.Age ?? 0,
                ActivityLevel = userAccount?.ActivityLevel ?? "Sedentary"
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProfile(SettingsViewModel model)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return RedirectToAction("Login");

            var userAccount = await _context.UserAccounts
                .FirstOrDefaultAsync(u => u.IdentityUserId == user.Id);

            if (userAccount != null)
            {
                // 1. Update basic info
                userAccount.Height = model.Height;
                userAccount.Gender = model.Gender;
                userAccount.Age = model.Age;
                userAccount.ActivityLevel = model.ActivityLevel;

                // 2. Update Multiplier based on selection
                userAccount.ActivityMultiplier = model.ActivityLevel switch
                {
                    "Sedentary" => 1.2,
                    "Lightly Active" => 1.375,
                    "Moderately Active" => 1.55,
                    "Very Active" => 1.725,
                    "Extra Active" => 1.9,
                    _ => 1.2
                };

                // 3. Recalculate Calories and Macros
                // Since we are inside the controller, we can call your calculation logic here
                var bmr = (10 * userAccount.Weight) + (6.25 * userAccount.Height) - (5 * userAccount.Age);
                bmr = (userAccount.Gender == "Male") ? bmr + 5 : bmr - 161;

                double tdee = bmr * userAccount.ActivityMultiplier;

                userAccount.DailyCalorieGoal = (int)Math.Round(tdee);
                userAccount.DailyProteinGoal = (int)((tdee * 0.30) / 4);
                userAccount.DailyCarbGoal = (int)((tdee * 0.45) / 4);
                userAccount.DailyFatGoal = (int)((tdee * 0.25) / 9);

                await _context.SaveChangesAsync();
                TempData["Success"] = "Profile updated successfully!";
            }

            return RedirectToAction("Settings");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAccount(string id)
        {
            var result = await _accountService.DeleteAccountAsync(id);
            if (result.Succeeded)
                return RedirectToAction("Landing", "Home");

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            return RedirectToAction("Settings");
        }

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var result = await _accountService.RegisterUserAsync(model);
            if (result.Succeeded)
                return RedirectToAction("Index", "CompleteProfile");

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            return View(model);
        }


        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string username, string password)
        {
            var result = await _accountService.LoginAsync(username, password);
            if (result.Succeeded)
                return RedirectToAction("Index", "Home");

            ModelState.AddModelError("", "Invalid login");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _accountService.LogoutAsync();
            return RedirectToAction("Landing", "Home");
        }
    }
}