using System.ComponentModel.DataAnnotations;

namespace CalorieTrackerApp.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Range(1, 2000)]
        public int Calories { get; set; }

        public bool IsHealthy { get; set; }

        [StringLength(200)]
        public string Img { get; set; } = string.Empty;
        public string Type { get; set; } = "Main";
        public string Tags { get; set; } = "";
        public string Ingredients { get; set; } = "";
        public string Instructions { get; set; } = "";

        public string Difficulty { get; set; } = "Easy"; // Easy, Medium, Hard
        public bool IsFavorite { get; set; }



    }
}

