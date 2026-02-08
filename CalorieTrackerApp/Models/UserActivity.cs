using System.ComponentModel.DataAnnotations;

namespace CalorieTrackerApp.Models
{
    public class UserActivity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;

        [Range(1, 3000)]
        public int CaloriesBurned { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; } = DateTime.Now;
        public int UserAccountId { get; set; }
        public UserAccount UserAccount { get; set; } = null!;
    }
}
