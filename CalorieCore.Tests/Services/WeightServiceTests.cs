using CalorieCore.DataModels;
using CalorieCore.Services;
using Xunit;
using Microsoft.EntityFrameworkCore;

namespace CalorieCore.Tests.Services
{
    public class WeightServiceTests : TestBase
    {
        [Fact]
        public async Task LogWeightAsync_ShouldAddRecord_AndReturnTrue()
        {
            // Arrange
            var db = GetDbContext();
            var service = new WeightService(db);
            var userId = "test-user-1";

            db.UserAccounts.Add(new UserAccount { Id = 1, IdentityUserId = userId });
            await db.SaveChangesAsync();

            // Act
            var result = await service.LogWeightAsync(userId, 85.5);

            // Assert
            Assert.True(result);
            Assert.Equal(1, await db.WeightLogs.CountAsync());

            var user = await db.UserAccounts.FirstAsync();
            Assert.Equal(85.5, user.Weight);
        }

        [Fact]
        public async Task GetChartDataAsync_ShouldReturnLogs_ForCorrectUser()
        {
            // Arrange
            var db = GetDbContext();
            var service = new WeightService(db);
            var userId = "me";

            db.UserAccounts.Add(new UserAccount { Id = 10, IdentityUserId = userId });
            db.WeightLogs.Add(new WeightLog { Weight = 70, DateRecorded = DateTime.Now, UserAccountId = 10 });
            await db.SaveChangesAsync();

            // Act 
            var result = await service.GetChartDataAsync(userId);

            // Assert
            Assert.Single(result);
            Assert.Equal(70, result[0].Weight);
        }

        [Fact]
        public async Task DeleteLogAsync_ShouldReturnFalse_IfLogDoesNotBelongToUser()
        {
            // Arrange
            var db = GetDbContext();
            var service = new WeightService(db);

            db.UserAccounts.Add(new UserAccount { Id = 1, IdentityUserId = "real-owner" });
            db.UserAccounts.Add(new UserAccount { Id = 2, IdentityUserId = "attacker" });

            db.WeightLogs.Add(new WeightLog { Id = 50, Weight = 100, UserAccountId = 1 });
            await db.SaveChangesAsync();

            // Act - Attacker tries to delete owner's log
            var result = await service.DeleteLogAsync(50, "attacker");

            // Assert
            Assert.False(result);
            Assert.Equal(1, await db.WeightLogs.CountAsync()); // Log should still exist
        }
        [Fact]
        public async Task LogWeight_NegativeWeight_ReturnsFalse()
        {
            var db = GetDbContext();
            var service = new WeightService(db);

            // Testing the 'weight <= 0' branch
            var result = await service.LogWeightAsync("user1", -5.0);

            Assert.False(result);
        }

        [Fact]
        public async Task GetChartData_ReturnsOnlyLastSevenEntries()
        {
            var db = GetDbContext();
            var service = new WeightService(db);
            var user = await db.UserAccounts.FirstAsync(u => u.IdentityUserId == "user1");

            for (int i = 1; i <= 10; i++)
            {
                db.WeightLogs.Add(new WeightLog { UserAccountId = user.Id, Weight = 70 + i, DateRecorded = DateTime.Now.AddDays(i) });
            }
            await db.SaveChangesAsync();

            var logs = await service.GetChartDataAsync("user1");

            
            Assert.Equal(7, logs.Count);
        }
    }
}