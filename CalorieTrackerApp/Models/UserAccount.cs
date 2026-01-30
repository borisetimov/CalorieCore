using System.ComponentModel.DataAnnotations;

public class UserAccount
{
    public int Id { get; set; }

    [Required]
    public string Username { get; set; } = "";

    [Required]
    public string Password { get; set; } = "";

    public int Age { get; set; }
    public double Weight { get; set; } 
    public double Height { get; set; }
    public string Goal { get; set; } = "Maintain"; 
    public int DailyCalorieGoal { get; set; }
    public string Gender { get; set; } = "Male";


}
