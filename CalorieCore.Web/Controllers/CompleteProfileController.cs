using CalorieCore.Data; 
using CalorieCore.Data.Migrations;
using CalorieCore.DataModels;
using CalorieCore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

[Authorize]
public class CompleteProfileController : Controller
{
    private readonly IProfileService _profileService;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ApplicationDbContext _context;

    public CompleteProfileController(
        IProfileService profileService,
        UserManager<IdentityUser> userManager,
        ApplicationDbContext context) 
    {
        _profileService = profileService;
        _userManager = userManager;
        _context = context;
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

        var identityUserId = _userManager.GetUserId(User);

        var userAccount = await _context.UserAccounts
            .FirstOrDefaultAsync(u => u.IdentityUserId == identityUserId);

        if (userAccount == null)
        {
            userAccount = new UserAccount { IdentityUserId = identityUserId };
            _context.UserAccounts.Add(userAccount);
        }

        userAccount.Age = model.Age;
        userAccount.Height = model.Height;
        userAccount.Weight = model.Weight;
        userAccount.Gender = model.Gender;
        userAccount.ActivityLevel = model.ActivityLevel;

        userAccount.ActivityMultiplier = model.ActivityLevel switch
        {
            "Sedentary" => 1.2,
            "Lightly Active" => 1.375,
            "Moderately Active" => 1.55,
            "Very Active" => 1.725,
            "Extra Active" => 1.9,
            _ => 1.2
        };

        var bmr = (10 * userAccount.Weight) + (6.25 * userAccount.Height) - (5 * userAccount.Age);
        bmr = (userAccount.Gender == "Male") ? bmr + 5 : bmr - 161;
        double tdee = bmr * userAccount.ActivityMultiplier;

        double targetCalories = model.Goal switch
        {
            "Lose" => tdee - 500,
            "Gain" => tdee + 500,
            _ => tdee
        };

        userAccount.DailyCalorieGoal = (int)Math.Round(targetCalories);
        userAccount.DailyProteinGoal = (int)((targetCalories * 0.30) / 4);
        userAccount.DailyCarbGoal = (int)((targetCalories * 0.45) / 4);
        userAccount.DailyFatGoal = (int)((targetCalories * 0.25) / 9);
        userAccount.IsProfileComplete = true;
        await _context.SaveChangesAsync();

        return RedirectToAction("Index", "Home");
    }
}