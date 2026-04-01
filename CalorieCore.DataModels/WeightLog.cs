using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalorieCore.DataModels
{
    public class WeightLog
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(30, 300)]
        public double Weight { get; set; }

        [Required]
        public DateTime DateRecorded { get; set; } = DateTime.Now;

        [Required]
        public int UserAccountId { get; set; }

        [ForeignKey("UserAccountId")]
        public virtual UserAccount? UserAccount { get; set; }
    }
}