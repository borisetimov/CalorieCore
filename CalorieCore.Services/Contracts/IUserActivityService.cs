using CalorieCore.DataModels;

namespace CalorieCore.Services
{
    public interface IUserActivityService
    {
        Task<List<UserActivity>> GetActivitiesByWeekAsync(string identityUserId, int offset);
        Task<UserActivity?> GetActivityByIdAsync(int id, string identityUserId);
        Task CreateActivityAsync(UserActivity activity, string identityUserId);
        Task<bool> UpdateActivityAsync(int id, UserActivity updatedActivity, string identityUserId);
        Task<bool> DeleteActivityAsync(int id, string identityUserId);
    }
}