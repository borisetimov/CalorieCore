using CalorieCore.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace CalorieCore.Services
{
    public interface IAccountService
    {
        Task<IdentityResult> RegisterUserAsync(RegisterViewModel model);
        Task<SignInResult> LoginAsync(string username, string password);
        Task LogoutAsync();
        Task<IdentityResult> DeleteAccountAsync(string userId);
    }
}