namespace CalorieCore.Services
{
    public class WeightStatus
    {
        public double BMI { get; set; }
        public string Category { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public double MinNormalWeight { get; set; }
        public double MaxNormalWeight { get; set; }
        public string Message { get; set; } = string.Empty;
    }

    public static class WeightCalculator
    {
        public static WeightStatus Analyze(double weightKg, double heightCm, int age)
        {
            if (heightCm <= 0) return new WeightStatus { Message = "Height required for BMI calculation." };

            double heightMeters = heightCm / 100;
            double bmi = weightKg / (heightMeters * heightMeters);

            double minWeight = 18.5 * (heightMeters * heightMeters);
            double maxWeight = 24.9 * (heightMeters * heightMeters);

            string category = bmi switch
            {
                < 18.5 => "Underweight",
                < 25.0 => "Normal weight",
                < 30.0 => "Overweight",
                _ => "Obese"
            };
            string colorClass = category switch
            {
                "Underweight" => "underweight",
                "Normal weight" => "normal",
                "Overweight" => "overweight",
                _ => "obese"
            };

            return new WeightStatus
            {
                BMI = Math.Round(bmi, 1),
                Category = category,
                Color = colorClass,
                MinNormalWeight = Math.Round(minWeight, 1),
                MaxNormalWeight = Math.Round(maxWeight, 1),
                Message = GetAdvice(category, age)
            };
        }

        private static string GetAdvice(string category, int age)
        {
            if (age > 65 && category == "Underweight") return "At your age, maintaining a bit more weight is often safer.";
            return category == "Normal weight" ? "You are within the healthy norm!" : "Consider consulting a nutritionist.";
        }
    }
}