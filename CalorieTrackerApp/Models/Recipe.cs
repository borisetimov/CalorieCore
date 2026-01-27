using System.ComponentModel.DataAnnotations;

namespace CalorieTrackerApp.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(500)]
        public string Description { get; set; } = null!;

        [Range(0, 2000)]
        public int Calories { get; set; }
    }
}
