using System;
using CalorieCore.DataModels; 

namespace CalorieCore.Services
{
    public class MacroResult
    {
        public double Calories { get; set; }
        public int Protein { get; set; }
        public int Carbs { get; set; }
        public int Fats { get; set; }
    }

    public interface INutritionService
    {
        MacroResult CalculateDailyMacros(double weight, double height, int age, string gender, double activityMultiplier = 1.2);
    }

    public class NutritionService : INutritionService
    {
        public MacroResult CalculateDailyMacros(double weight, double height, int age, string gender, double activityMultiplier = 1.2)
        {
            // 1. Calculate BMR using Mifflin-St Jeor
            double bmr = (10 * weight) + (6.25 * height) - (5 * age);

            // Adjust BMR based on Gender
            if (gender != null && gender.Equals("Male", StringComparison.OrdinalIgnoreCase))
            {
                bmr += 5;
            }
            else
            {
                bmr -= 161;
            }

            // 2. Calculate TDEE (Total Daily Energy Expenditure)
            double tdee = bmr * activityMultiplier;

            // 3. Calculate Macros based on standard 30/45/25 split
            return new MacroResult
            {
                Calories = Math.Round(tdee),
                Protein = (int)((tdee * 0.30) / 4), // 4 cal per gram
                Carbs = (int)((tdee * 0.45) / 4),   // 4 cal per gram
                Fats = (int)((tdee * 0.25) / 9)     // 9 cal per gram
            };
        }
    }
}