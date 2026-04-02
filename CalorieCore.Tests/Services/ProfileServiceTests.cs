using CalorieCore.DataModels;
using CalorieCore.Services;
using CalorieCore.ViewModels; // Ensure this matches your ViewModel namespace
using Xunit;
using Microsoft.EntityFrameworkCore;

namespace CalorieCore.Tests.Services
{
    public class ProfileServiceTests : TestBase
    {
        [Fact]
        public async Task UpdateUserProfileAsync_ShouldCreateNewAccount_IfNoneExists()
        {
            var db = GetDbContext();
            var service = new ProfileService(db);
            var userId = "new-user-123";
            var model = new CompleteProfileViewModel
            {
                Age = 25,
                Weight = 80,
                Height = 180,
                Gender = "Male",
                Goal = "Maintain"
            };

            // Act
            await service.UpdateUserProfileAsync(userId, model);

            // Assert
            var account = await db.UserAccounts.FirstOrDefaultAsync(u => u.IdentityUserId == userId);
            Assert.NotNull(account);
            Assert.True(account.IsProfileComplete);
            Assert.Equal(80, account.Weight);
        }

        [Fact]
        public async Task IsProfileCompleteAsync_ShouldReturnFalse_WhenUserDoesNotExist()
        {
            var db = GetDbContext();
            var service = new ProfileService(db);

            // Act
            var result = await service.IsProfileCompleteAsync("non-existent-id");

            // Assert
            Assert.False(result);
        }
    }
}