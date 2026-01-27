using System.ComponentModel.DataAnnotations;

namespace CalorieTrackerApp.Models
{
    public class UserActivity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        [Range(1, 5000)]
        public int CaloriesBurned { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public int UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; } = null!;
    }
}