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

            // Fetch the linked UserAccount to get Height and Gender
            var userAccount = await _context.UserAccounts
                .FirstOrDefaultAsync(u => u.IdentityUserId == user.Id);

            var model = new SettingsViewModel
            {
                Id = user.Id,
                Username = user.UserName ?? "",
                Email = user.Email ?? "",
                // Pulling data from UserAccount if it exists
                Height = userAccount?.Height ?? 0,
                Gender = userAccount?.Gender ?? "Male"
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
                userAccount.Height = model.Height;
                userAccount.Gender = model.Gender;

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