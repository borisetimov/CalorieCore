using System.ComponentModel.DataAnnotations;

namespace CalorieCore.DataModels
{
    public class Recipe
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(1000, MinimumLength = 10)]
        public string Description { get; set; } = string.Empty;

        [Range(1, 2000)]
        public int Calories { get; set; }

        public bool IsHealthy { get; set; }

        [StringLength(200)]
        public string Img { get; set; } = string.Empty;

        [Required]
        [StringLength(30)]
        public string Type { get; set; } = "Main";

        [StringLength(200)]
        public string Tags { get; set; } = string.Empty;

        [Required]
        [StringLength(2000, MinimumLength = 5)]
        public string Ingredients { get; set; } = string.Empty;

        [Required]
        [StringLength(4000, MinimumLength = 10)]
        public string Instructions { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string Difficulty { get; set; } = "Easy";

        public bool IsFavorite { get; set; }

        public int? UserAccountId { get; set; }

        public UserAccount? UserAccount { get; set; }

        public bool IsGlobal { get; set; } = false;
    }
}
