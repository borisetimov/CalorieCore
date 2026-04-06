using CalorieCore.Data;
using CalorieCore.Data.Migrations;
using CalorieCore.DataModels;
using Microsoft.EntityFrameworkCore;
using System;

namespace CalorieCore.Tests.Services
{
    public abstract class TestBase
    {
        public ApplicationDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var dbContext = new ApplicationDbContext(options);
            dbContext.Database.EnsureCreated();

            var testUser = new UserAccount
            {
                IdentityUserId = "user1",
                Age = 25,
                Weight = 70,
                Height = 175,
                Goal = "Maintain",
                Gender = "Male",
                DailyCalorieGoal = 2000,
                IsProfileComplete = true
            };

            dbContext.UserAccounts.Add(testUser);
            dbContext.SaveChanges();

            return dbContext;
        }
    }
}