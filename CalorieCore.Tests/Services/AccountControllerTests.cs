using CalorieCore.Web.Controllers;
using CalorieCore.Services;
using CalorieCore.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Moq;
using System.Security.Claims;
using Xunit;

namespace CalorieCore.Tests.Controllers
{
    public class AccountControllerTests
    {
        private readonly Mock<IAccountService> _mockAccountService;
        private readonly Mock<UserManager<IdentityUser>> _mockUserManager;
        private readonly AccountController _controller;

        public AccountControllerTests()
        {
            _mockAccountService = new Mock<IAccountService>();

            // Setting up a Mock UserManager is a bit complex, but this standard setup works:
            var store = new Mock<IUserStore<IdentityUser>>();
            _mockUserManager = new Mock<UserManager<IdentityUser>>(store.Object, null, null, null, null, null, null, null, null);

            _controller = new AccountController(_mockAccountService.Object, _mockUserManager.Object);
        }

        [Fact]
        public async Task Settings_UserNotLoggedIn_RedirectsToLogin()
        {
            // Arrange: GetUserAsync returns null
            _mockUserManager.Setup(x => x.GetUserAsync(It.IsAny<ClaimsPrincipal>()))
                            .ReturnsAsync((IdentityUser)null!);

            // Act
            var result = await _controller.Settings();

            // Assert
            var redirect = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Login", redirect.ActionName);
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
    }
}