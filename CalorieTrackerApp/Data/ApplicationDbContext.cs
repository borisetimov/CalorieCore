using CalorieTrackerApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CalorieTrackerApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; } = null!;
        public DbSet<UserActivity> Activities { get; set; } = null!;
        public DbSet<Recipe> Recipes { get; set; } = null!;
    }
}
