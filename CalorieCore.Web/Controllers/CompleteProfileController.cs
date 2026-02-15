using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Authorize]
public class CompleteProfileController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public CompleteProfileController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var identityUser = await _userManager.GetUserAsync(User);
        var existingAccount = await _context.UserAccounts
            .FirstOrDefaultAsync(u => u.IdentityUserId == identityUser.Id);

        if (existingAccount != null && existingAccount.IsProfileComplete)
        {
            return RedirectToAction("Index", "Home");
        }

        return View(new CompleteProfileViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Index(CompleteProfileViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var identityUser = await _userManager.GetUserAsync(User);
        var existingAccount = await _context.UserAccounts
            .FirstOrDefaultAsync(u => u.IdentityUserId == identityUser.Id);

        var dailyCalories = CalorieCalculator.Calculate(
            model.Weight, model.Height, model.Age, model.Gender, model.Goal
        );

        if (existingAccount == null)
        {
            existingAccount = new UserAccount
            {
                IdentityUserId = identityUser.Id,
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

        return RedirectToAction("Index", "Home");
    }
}
