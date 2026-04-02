using CalorieCore.DataModels;
using CalorieCore.Data.Migrations;
using Microsoft.EntityFrameworkCore;

namespace CalorieCore.Services
{
    public class WeightService : IWeightService
    {
        private readonly ApplicationDbContext _context;

        public WeightService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<WeightLog>> GetChartDataAsync(string userId)
        {
            var userAccount = await _context.UserAccounts
                .Include(u => u.WeightLogs)
                .FirstOrDefaultAsync(u => u.IdentityUserId == userId);

            if (userAccount == null) return new List<WeightLog>();

            return userAccount.WeightLogs
                .OrderByDescending(w => w.DateRecorded)
                .Take(7)
                .OrderBy(w => w.DateRecorded)
                .ToList();
        }

        public async Task<bool> LogWeightAsync(string userId, double weight)
        {
            var userAccount = await _context.UserAccounts
                .FirstOrDefaultAsync(u => u.IdentityUserId == userId);

            if (userAccount == null || weight <= 0) return false;

            var entry = new WeightLog
            {
                Weight = weight,
                DateRecorded = DateTime.Now,
                UserAccountId = userAccount.Id
            };

            _context.WeightLogs.Add(entry);
            userAccount.Weight = weight; // Sync the main profile weight

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteLogAsync(int id, string userId)
        {
            var userAccount = await _context.UserAccounts
                .FirstOrDefaultAsync(u => u.IdentityUserId == userId);

            if (userAccount == null) return false;

            var log = await _context.WeightLogs
                .FirstOrDefaultAsync(l => l.Id == id && l.UserAccountId == userAccount.Id);

            if (log == null) return false;

            _context.WeightLogs.Remove(log);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}