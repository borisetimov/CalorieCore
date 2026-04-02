using CalorieCore.DataModels;

namespace CalorieCore.Services
{
    public interface IProfileService
    {
        Task<bool> IsProfileCompleteAsync(string identityUserId);
        Task UpdateUserProfileAsync(string identityUserId, CompleteProfileViewModel model);
    }
}