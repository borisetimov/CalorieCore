namespace CalorieCore.ViewModels
{
    public class SettingsViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Age { get; set; }
        public string ActivityLevel { get; set; } = "Sedentary";
        public double Height { get; set; }
        public string Gender { get; set; } = "Male";
    }
}

