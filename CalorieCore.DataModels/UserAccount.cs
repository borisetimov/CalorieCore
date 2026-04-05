using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CalorieCore.DataModels
{
    public class UserAccount
    {
        public int Id { get; set; }
        public string IdentityUserId { get; set; } = string.Empty;
        public IdentityUser? IdentityUser { get; set; }

        [Range(10, 120)]
        public int Age { get; set; }

        // Initialized to prevent nulls
        public string ActivityLevel { get; set; } = "Sedentary";

        public double ActivityMultiplier { get; set; } = 1.2;

        [Range(30, 300)]
        public double Weight { get; set; }

        [Range(100, 250)]
        public double Height { get; set; }

        [Required, StringLength(20)]
        public string Goal { get; set; } = "Maintain";

        [Required, StringLength(10)]
        public string Gender { get; set; } = "Male";

        [Range(500, 10000)] // Expanded range for high-activity athletes
        public int DailyCalorieGoal { get; set; }

        // --- NEW NUTRITION FIELDS ---
        public int DailyProteinGoal { get; set; }
        public int DailyCarbGoal { get; set; }
        public int DailyFatGoal { get; set; }
        // ----------------------------

        public bool IsProfileComplete { get; set; } = false;

        public ICollection<WeightLog> WeightLogs { get; set; } = new List<WeightLog>();
        public ICollection<Meal> Meals { get; set; } = new List<Meal>();
        public ICollection<UserActivity> Activities { get; set; } = new List<UserActivity>();
    }
}