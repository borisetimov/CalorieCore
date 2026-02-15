using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CalorieTrackerApp.Models
{
    public class UserAccount
    {
        public int Id { get; set; }
        public string IdentityUserId { get; set; } = string.Empty;
        public IdentityUser? IdentityUser { get; set; }

        [Range(10, 120)]
        public int Age { get; set; }

        [Range(30, 300)]
        public double Weight { get; set; }

        [Range(100, 250)]
        public double Height { get; set; }

        [Required, StringLength(20)]
        public string Goal { get; set; } = "Maintain";

        [Required, StringLength(10)]
        public string Gender { get; set; } = "Male";

        [Range(1000, 6000)]
        public int DailyCalorieGoal { get; set; }

        public bool IsProfileComplete { get; set; } = false;

        public ICollection<Meal> Meals { get; set; } = new List<Meal>();
        public ICollection<UserActivity> Activities { get; set; } = new List<UserActivity>();
    }
}
