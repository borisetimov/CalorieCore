using CalorieTrackerApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class AccountController : Controller
{
    private readonly ApplicationDbContext _context;

    [HttpGet]
    public IActionResult Settings()
    {
        var username = HttpContext.Session.GetString("Username");
        if (username == null)
            return RedirectToAction("Login");

        var user = _context.UserAccounts.FirstOrDefault(u => u.Username == username);
        return View(user);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteAccount(int id)
    {
        var user = await _context.UserAccounts.FindAsync(id);
        if (user != null)
        {
            _context.UserAccounts.Remove(user);
            await _context.SaveChangesAsync();
            HttpContext.Session.Clear();
        }
        return RedirectToAction("Landing", "Home");
    }
    public AccountController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(string username, string password)
    {
        var user = await _context.UserAccounts
           .FirstOrDefaultAsync(u => u.Username == username);

        if (user != null && PasswordHelper.VerifyPassword(password, user.Password))
        {
            HttpContext.Session.SetString("Username", user.Username);
            return RedirectToAction("Index", "Home");
        }


        if (user != null)
        {
            HttpContext.Session.SetString("Username", user.Username);
            return RedirectToAction("Index", "Home");
        }

        ViewBag.Error = "Invalid login";
        return View();
    }
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var exists = await _context.UserAccounts
            .AnyAsync(u => u.Username == model.Username);

        if (exists)
        {
            ModelState.AddModelError("", "Username already exists");
            return View(model);
        }

        var dailyCalories = CalorieCalculator.Calculate(
          model.Weight,
          model.Height,
          model.Age,
          model.Goal
);

        var user = new UserAccount
        {
            Username = model.Username,
            Password = PasswordHelper.HashPassword(model.Password),
            Age = model.Age,
            Weight = model.Weight,
            Height = model.Height,
            Goal = model.Goal,
            DailyCalorieGoal = dailyCalories
        };


        _context.UserAccounts.Add(user);
        await _context.SaveChangesAsync();

        HttpContext.Session.SetString("Username", user.Username);
        return RedirectToAction("Index", "Home");
    }



    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index", "Home");
    }
}
