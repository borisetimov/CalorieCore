using CalorieCore.DataModels;
using CalorieCore.Data.Migrations;
using Microsoft.EntityFrameworkCore;

namespace CalorieCore.Services
{
    public class UserActivityService : IUserActivityService
    {
        private readonly ApplicationDbContext _context;

        public UserActivityService(ApplicationDbContext context)
        {
            _context = context;
        }

        private async Task<int?> GetUserAccountIdAsync(string identityUserId)
        {
            var user = await _context.UserAccounts
                .FirstOrDefaultAsync(u => u.IdentityUserId == identityUserId);
            return user?.Id;
        }

        public async Task<List<UserActivity>> GetActivitiesByWeekAsync(string identityUserId, int offset)
        {
            var userAccountId = await GetUserAccountIdAsync(identityUserId);
            if (userAccountId == null) return new List<UserActivity>();

            DayOfWeek firstDayOfWeek = DayOfWeek.Monday;
            DateTime baseDate = DateTime.Today.AddDays(offset * 7);
            int diff = (7 + (baseDate.DayOfWeek - firstDayOfWeek)) % 7;
            DateTime startOfWeek = baseDate.AddDays(-1 * diff).Date;
            DateTime endOfWeek = startOfWeek.AddDays(7);

            return await _context.Activities
                .Where(a => a.UserAccountId == userAccountId && a.Date >= startOfWeek && a.Date < endOfWeek)
                .OrderByDescending(a => a.Date)
                .ToListAsync();
        }

        public async Task<UserActivity?> GetActivityByIdAsync(int id, string identityUserId)
        {
            var userAccountId = await GetUserAccountIdAsync(identityUserId);
            return await _context.Activities
                .FirstOrDefaultAsync(a => a.Id == id && a.UserAccountId == userAccountId);
        }

        public async Task CreateActivityAsync(UserActivity activity, string identityUserId)
        {
            var userAccountId = await GetUserAccountIdAsync(identityUserId);
            if (userAccountId != null)
            {
                activity.UserAccountId = userAccountId.Value;
                activity.Date = DateTime.Now;
                _context.Activities.Add(activity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> UpdateActivityAsync(int id, UserActivity updatedActivity, string identityUserId)
        {
            var activity = await GetActivityByIdAsync(id, identityUserId);
            if (activity == null) return false;

            activity.Name = updatedActivity.Name;
            activity.CaloriesBurned = updatedActivity.CaloriesBurned;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteActivityAsync(int id, string identityUserId)
        {
            var activity = await GetActivityByIdAsync(id, identityUserId);
            if (activity == null) return false;

            _context.Activities.Remove(activity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}