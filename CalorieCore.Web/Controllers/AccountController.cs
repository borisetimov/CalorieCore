using CalorieCore.ViewModels;
using CalorieCore.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CalorieCore.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(IAccountService accountService, UserManager<IdentityUser> userManager)
        {
            _accountService = accountService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Settings()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return RedirectToAction("Login");

            var model = new SettingsViewModel
            {
                Id = user.Id,
                Username = user.UserName ?? "",
                Email = user.Email ?? ""
            };
            return View(model);
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