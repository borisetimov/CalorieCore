using CalorieTrackerApp.Data;
using CalorieTrackerApp.Models;
using Microsoft.AspNetCore.Mvc;

public class MealsController : Controller
{
    private readonly ApplicationDbContext _context;

    public MealsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var username = HttpContext.Session.GetString("Username");

        var meals = _context.Meals
            .Where(m => m.Username == username)
            .OrderByDescending(m => m.Date)
            .ToList();

        return View(meals);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Meal meal)
    {
        meal.Username = HttpContext.Session.GetString("Username")!;
        meal.Date = DateTime.Now;

        _context.Meals.Add(meal);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }
}

