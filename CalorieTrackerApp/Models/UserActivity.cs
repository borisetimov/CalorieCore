using System.ComponentModel.DataAnnotations;

namespace CalorieTrackerApp.Models
{
    public class UserActivity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Range(1, 5000)]
        public int CaloriesBurned { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        [Required]
        public int UserProfileId { get; set; }

        public UserProfile? UserProfile { get; set; } = null!;
    }
}