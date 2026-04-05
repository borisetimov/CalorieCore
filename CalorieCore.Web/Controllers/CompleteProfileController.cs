using CalorieCore.Data; // Ensure this matches your actual namespace for ApplicationDbContext
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
    private readonly ApplicationDbContext _context; // Added to fix CS0103

    public CompleteProfileController(
        IProfileService profileService,
        UserManager<IdentityUser> userManager,
        ApplicationDbContext context) // Inject context here
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

        // Try to find the account, or create a new one if it's missing
        var userAccount = await _context.UserAccounts
            .FirstOrDefaultAsync(u => u.IdentityUserId == identityUserId);

        if (userAccount == null)
        {
            userAccount = new UserAccount { IdentityUserId = identityUserId };
            _context.UserAccounts.Add(userAccount);
        }

        // 1. Map physical data
        userAccount.Age = model.Age;
        userAccount.Height = model.Height;
        userAccount.Weight = model.Weight;
        userAccount.Gender = model.Gender;
        userAccount.ActivityLevel = model.ActivityLevel;

        // 2. Set Multiplier based on ActivityLevel
        userAccount.ActivityMultiplier = model.ActivityLevel switch
        {
            "Sedentary" => 1.2,
            "Lightly Active" => 1.375,
            "Moderately Active" => 1.55,
            "Very Active" => 1.725,
            "Extra Active" => 1.9,
            _ => 1.2
        };

        // 3. Calculate Base TDEE
        var bmr = (10 * userAccount.Weight) + (6.25 * userAccount.Height) - (5 * userAccount.Age);
        bmr = (userAccount.Gender == "Male") ? bmr + 5 : bmr - 161;
        double tdee = bmr * userAccount.ActivityMultiplier;

        // 4. Adjust TDEE based on the Goal dropdown
        double targetCalories = model.Goal switch
        {
            "Lose" => tdee - 500,
            "Gain" => tdee + 500,
            _ => tdee
        };

        // 5. Set Macros
        userAccount.DailyCalorieGoal = (int)Math.Round(targetCalories);
        userAccount.DailyProteinGoal = (int)((targetCalories * 0.30) / 4);
        userAccount.DailyCarbGoal = (int)((targetCalories * 0.45) / 4);
        userAccount.DailyFatGoal = (int)((targetCalories * 0.25) / 9);
        userAccount.IsProfileComplete = true;
        await _context.SaveChangesAsync();

        // Now HomeController.Index will find the user and show the Dashboard!
        return RedirectToAction("Index", "Home");
    }
}