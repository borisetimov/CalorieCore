using CalorieCore.Data; // Verify this matches your ApplicationDbContext namespace
using CalorieCore.Data.Migrations;
using CalorieCore.DataModels;
using CalorieCore.Services;
using CalorieCore.ViewModels;
using CalorieCore.Web.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Xunit;

namespace CalorieCore.Tests.Controllers
{
    public class AccountControllerTests : IDisposable
    {
        private readonly Mock<IAccountService> _mockAccountService;
        private readonly Mock<UserManager<IdentityUser>> _mockUserManager;
        private readonly ApplicationDbContext _context;
        private readonly AccountController _controller;

        public AccountControllerTests()
        {
            _mockAccountService = new Mock<IAccountService>();

            var store = new Mock<IUserStore<IdentityUser>>();
            _mockUserManager = new Mock<UserManager<IdentityUser>>(
                store.Object, null!, null!, null!, null!, null!, null!, null!, null!);

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _context = new ApplicationDbContext(options);

            _controller = new AccountController(_mockAccountService.Object, _mockUserManager.Object, _context);
        }

        private Mock<UserManager<IdentityUser>> GetMockUserManager(IdentityUser user)
        {
            var store = new Mock<IUserStore<IdentityUser>>();
            var mgr = new Mock<UserManager<IdentityUser>>(
                store.Object, null!, null!, null!, null!, null!, null!, null!, null!);

            mgr.Setup(x => x.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync(user);
            mgr.Setup(x => x.GetUserId(It.IsAny<ClaimsPrincipal>())).Returns(user.Id);
            return mgr;
        }

        [Fact]
        public async Task Settings_UserNotLoggedIn_RedirectsToLogin()
        {
            // Arrange
            _mockUserManager.Setup(x => x.GetUserAsync(It.IsAny<ClaimsPrincipal>()))
                            .ReturnsAsync((IdentityUser)null!);

            // Act
            var result = await _controller.Settings();

            // Assert
            var redirect = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Login", redirect.ActionName);
        }

        [Fact]
        public async Task UpdateProfile_UpdatesHeightAndGender_ReturnsRedirect()
        {
            // Arrange
            var userId = "user123";
            var user = new IdentityUser { Id = userId, UserName = "testuser" };
            var account = new UserAccount { IdentityUserId = userId, Height = 170, Gender = "Male" };

            _context.UserAccounts.Add(account);
            await _context.SaveChangesAsync();

            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, userId),
        new Claim(ClaimTypes.Name, "testuser")
    };
            var identity = new ClaimsIdentity(claims, "TestAuthType");
            var claimsPrincipal = new ClaimsPrincipal(identity);

            var controllerWithUser = new AccountController(
                _mockAccountService.Object,
                GetMockUserManager(user).Object,
                _context);

            var tempDataProvider = new Mock<ITempDataProvider>();
            var tempData = new TempDataDictionary(new DefaultHttpContext(), tempDataProvider.Object);

            controllerWithUser.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = claimsPrincipal }
            };
            controllerWithUser.TempData = tempData; 

            var model = new SettingsViewModel { Height = 185.5, Gender = "Female" };

            // Act
            var result = await controllerWithUser.UpdateProfile(model);

            // Assert
            var updatedAccount = await _context.UserAccounts.FirstAsync(u => u.IdentityUserId == userId);
            Assert.Equal(185.5, updatedAccount.Height);
            Assert.Equal("Female", updatedAccount.Gender);
            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public async Task Register_InvalidModel_ReturnsViewWithModel()
        {
            // Arrange
            _controller.ModelState.AddModelError("Email", "Required");
            var model = new RegisterViewModel();

            // Act
            var result = await _controller.Register(model);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(model, viewResult.Model);
        }

        [Fact]
        public async Task Register_Succeeded_RedirectsToCompleteProfile()
        {
            // Arrange
            var model = new RegisterViewModel { Email = "test@test.com" };
            _mockAccountService.Setup(x => x.RegisterUserAsync(model))
                               .ReturnsAsync(IdentityResult.Success);

            // Act
            var result = await _controller.Register(model);

            // Assert
            var redirect = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirect.ActionName);
            Assert.Equal("CompleteProfile", redirect.ControllerName);
        }

        [Fact]
        public async Task Login_Failed_ReturnsViewWithErrorMessage()
        {
            // Arrange
            _mockAccountService.Setup(x => x.LoginAsync("user", "pass"))
                               .ReturnsAsync(Microsoft.AspNetCore.Identity.SignInResult.Failed);

            // Act
            var result = await _controller.Login("user", "pass");

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.True(_controller.ModelState.ContainsKey(""));
            Assert.Equal("Invalid login", _controller.ModelState[""]!.Errors[0].ErrorMessage);
        }

        [Fact]
        public async Task Logout_RedirectsToLanding()
        {
            // Act
            var result = await _controller.Logout();

            // Assert
            var redirect = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Landing", redirect.ActionName);
            _mockAccountService.Verify(x => x.LogoutAsync(), Times.Once);
        }

        [Fact]
        public async Task DeleteAccount_Succeeded_RedirectsToLanding()
        {
            // Arrange
            _mockAccountService.Setup(x => x.DeleteAccountAsync("123"))
                               .ReturnsAsync(IdentityResult.Success);

            // Act
            var result = await _controller.DeleteAccount("123");

            // Assert
            var redirect = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Landing", redirect.ActionName);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}