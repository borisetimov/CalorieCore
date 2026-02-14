using System.ComponentModel.DataAnnotations;

public class CompleteProfileViewModel
{
    [Required, Range(10, 120)]
    public int Age { get; set; }

    [Required, Range(30, 300)]
    public double Weight { get; set; }

    [Required, Range(100, 250)]
    public double Height { get; set; }

    [Required, StringLength(20)]
    public string Goal { get; set; } = "Maintain";

    [Required, StringLength(10)]
    public string Gender { get; set; } = "Male";
}
