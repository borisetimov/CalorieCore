using CalorieCore.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace CalorieCore.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> RegisterUserAsync(RegisterViewModel model)
        {
            var user = new IdentityUser { UserName = model.Username, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
            }
            return result;
        }

        public async Task<SignInResult> LoginAsync(string username, string password)
        {
            return await _signInManager.PasswordSignInAsync(username, password, false, false);
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> DeleteAccountAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return IdentityResult.Failed(new IdentityError { Description = "User not found" });

            await _signInManager.SignOutAsync();
            return await _userManager.DeleteAsync(user);
        }
    }
}