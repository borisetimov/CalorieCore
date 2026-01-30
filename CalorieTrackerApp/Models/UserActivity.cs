using System.ComponentModel.DataAnnotations;

namespace CalorieTrackerApp.Models
{
    public class UserActivity
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public int CaloriesBurned { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public string Username { get; set; } = "";
    }

}