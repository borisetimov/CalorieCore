using CalorieCore.Data.Migrations;
using CalorieCore.DataModels;
using Microsoft.EntityFrameworkCore;

namespace CalorieCore.Services
{
    public class ProfileService : IProfileService
    {
        private readonly ApplicationDbContext _context;

        public ProfileService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> IsProfileCompleteAsync(string identityUserId)
        {
            var account = await _context.UserAccounts
                .FirstOrDefaultAsync(u => u.IdentityUserId == identityUserId);
            return account?.IsProfileComplete ?? false;
        }

        public async Task UpdateUserProfileAsync(string identityUserId, CompleteProfileViewModel model)
        {
            var existingAccount = await _context.UserAccounts
                .FirstOrDefaultAsync(u => u.IdentityUserId == identityUserId);

            var dailyCalories = CalorieCalculator.Calculate(
                model.Weight, model.Height, model.Age, model.Gender, model.Goal
            );

            if (existingAccount == null)
            {
                existingAccount = new UserAccount
                {
                    IdentityUserId = identityUserId,
                    IsProfileComplete = true,
                    Age = model.Age,
                    Weight = model.Weight,
                    Height = model.Height,
                    Gender = model.Gender,
                    Goal = model.Goal,
                    DailyCalorieGoal = dailyCalories
                };
                _context.UserAccounts.Add(existingAccount);
            }
            else
            {
                existingAccount.Age = model.Age;
                existingAccount.Weight = model.Weight;
                existingAccount.Height = model.Height;
                existingAccount.Gender = model.Gender;
                existingAccount.Goal = model.Goal;
                existingAccount.DailyCalorieGoal = dailyCalories;
                existingAccount.IsProfileComplete = true;
            }

            await _context.SaveChangesAsync();
        }
    }
}