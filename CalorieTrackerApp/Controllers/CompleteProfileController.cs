using CalorieTrackerApp.Data;
using CalorieTrackerApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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
    public IActionResult Index()
    {
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

        if (existingAccount != null)
            return RedirectToAction("Index", "Home");

        var dailyCalories = CalorieCalculator.Calculate(
            model.Weight, model.Height, model.Age, model.Gender, model.Goal
        );

        var userAccount = new UserAccount
        {
            IdentityUserId = identityUser.Id,
            Age = model.Age,
            Weight = model.Weight,
            Height = model.Height,
            Gender = model.Gender,
            Goal = model.Goal,
            DailyCalorieGoal = dailyCalories
        };

        _context.UserAccounts.Add(userAccount);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index", "Home");
    }
}
