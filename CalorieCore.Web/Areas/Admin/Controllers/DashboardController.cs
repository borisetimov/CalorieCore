using CalorieCore.Data.Migrations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Area("Admin")]
[Authorize(Roles = "Administrator")]
public class DashboardController : Controller
{
    private readonly ApplicationDbContext _context;
    public DashboardController(ApplicationDbContext context) => _context = context;

    public async Task<IActionResult> Index()
    {
        // Simple stats for the admin
        ViewBag.UserCount = await _context.UserAccounts.CountAsync();
        ViewBag.TotalLogs = await _context.WeightLogs.CountAsync();
        // Get the 5 most recent users to join
        ViewBag.RecentUsers = await _context.UserAccounts
            .OrderByDescending(u => u.Id)
            .Take(5)
            .ToListAsync();
        return View();
    }
} // Will expand with more detailed analytics and user management features in the future.