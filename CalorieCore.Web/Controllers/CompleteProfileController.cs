using System.Security.Claims;
using CalorieCore.DataModels;
using CalorieCore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

[Authorize]
public class CompleteProfileController : Controller
{
    private readonly IProfileService _profileService;
    private readonly UserManager<IdentityUser> _userManager;

    public CompleteProfileController(IProfileService profileService, UserManager<IdentityUser> userManager)
    {
        _profileService = profileService;
        _userManager = userManager;
    }

    private string CurrentUserId => _userManager.GetUserId(User)!;

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        if (await _profileService.IsProfileCompleteAsync(CurrentUserId))
        {
            return RedirectToAction("Index", "Home");
        }

        return View(new CompleteProfileViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Index(CompleteProfileViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        await _profileService.UpdateUserProfileAsync(CurrentUserId, model);

        return RedirectToAction("Index", "Home");
    }
}