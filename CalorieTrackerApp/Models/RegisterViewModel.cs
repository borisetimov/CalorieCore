using System.ComponentModel.DataAnnotations;

public class RegisterViewModel
{
    [Required]
    public string Username { get; set; } = "";

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = "";

    [Required]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Passwords do not match")]
    public string ConfirmPassword { get; set; } = "";
    [Required]
    public int Age { get; set; }
    [Required]
    public double Weight { get; set; }
    [Required]
    public double Height { get; set; }
    [Required]
    public string Goal { get; set; } = "Maintain";

    [Required]
    public string Gender { get; set; } = "Male";


}
