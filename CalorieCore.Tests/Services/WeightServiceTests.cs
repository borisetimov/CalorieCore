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
            var db = GetDbContext();
            var service = new WeightService(db);
            var userId = "user1";

            // Act
            var result = await service.LogWeightAsync(userId, 85.5);

            // Assert
            Assert.True(result);
            Assert.Equal(1, await db.WeightLogs.CountAsync());

            var user = await db.UserAccounts.FirstAsync(u => u.IdentityUserId == userId);
            Assert.Equal(85.5, user.Weight);
        }

        [Fact]
        public async Task GetChartDataAsync_ShouldReturnLogs_ForCorrectUser()
        {
            var db = GetDbContext();
            var service = new WeightService(db);
            var userId = "user1";
            var user = await db.UserAccounts.FirstAsync(u => u.IdentityUserId == userId);

            db.WeightLogs.Add(new WeightLog { Weight = 70, DateRecorded = DateTime.Now, UserAccountId = user.Id });
            await db.SaveChangesAsync();

            // Act 
            var result = await service.GetChartDataAsync(userId);

            // Assert
            Assert.Single(result);
            Assert.Equal(70, result[0].Weight);
        }

        [Fact]
        public async Task GetChartDataAsync_ShouldReturnInChronologicalOrder()
        {
            var db = GetDbContext();
            var service = new WeightService(db);
            var user = await db.UserAccounts.FirstAsync(u => u.IdentityUserId == "user1");

            // Adding logs out of order
            db.WeightLogs.Add(new WeightLog { Weight = 90, DateRecorded = DateTime.Now, UserAccountId = user.Id });
            db.WeightLogs.Add(new WeightLog { Weight = 80, DateRecorded = DateTime.Now.AddDays(-1), UserAccountId = user.Id });
            await db.SaveChangesAsync();

            // Act
            var logs = await service.GetChartDataAsync("user1");

            
            Assert.Equal(80, logs[0].Weight);
            Assert.Equal(90, logs[1].Weight);
        }

        [Fact]
        public async Task DeleteLogAsync_ShouldReturnFalse_IfLogDoesNotBelongToUser()
        {
            var db = GetDbContext();
            var service = new WeightService(db);

            var attacker = new UserAccount { IdentityUserId = "attacker", Gender = "Male", Goal = "Maintain" };
            db.UserAccounts.Add(attacker);

            var owner = await db.UserAccounts.FirstAsync(u => u.IdentityUserId == "user1");
            var log = new WeightLog { Weight = 100, UserAccountId = owner.Id };
            db.WeightLogs.Add(log);
            await db.SaveChangesAsync();

            // Act
            var result = await service.DeleteLogAsync(log.Id, "attacker");

            // Assert
            Assert.False(result);
            Assert.Equal(1, await db.WeightLogs.CountAsync());
        }

        [Fact]
        public async Task LogWeight_NegativeWeight_ReturnsFalse()
        {
            var db = GetDbContext();
            var service = new WeightService(db);

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

        [Fact]
        public async Task GetUserAccountWithLogsAsync_ShouldIncludeLogsList()
        {
            var db = GetDbContext();
            var service = new WeightService(db);
            var user = await db.UserAccounts.FirstAsync(u => u.IdentityUserId == "user1");

            db.WeightLogs.Add(new WeightLog { Weight = 75, UserAccountId = user.Id });
            await db.SaveChangesAsync();

            // Act
            var result = await service.GetUserAccountWithLogsAsync("user1");

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result.WeightLogs);
        }
    }
}