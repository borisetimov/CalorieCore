using Xunit;
using CalorieCore.Services;

namespace CalorieCore.Tests.Services
{
    public class CalorieCalculatorTests
    {
        [Theory]
        // Male: (10*70) + (6.25*170) - (5*25) + 5 = 700 + 1062.5 - 125 + 5 = 1642.5
        [InlineData(70, 170, 25, "Male", "Maintain", 1642)]
        // Male Lose: 1642 - 500 = 1142
        [InlineData(70, 170, 25, "Male", "Lose", 1142)]
        // Male Gain: 1642 + 500 = 2142
        [InlineData(70, 170, 25, "Male", "Gain", 2142)]
        // Female: (10*60) + (6.25*160) - (5*30) - 161 = 600 + 1000 - 150 - 161 = 1289
        [InlineData(60, 160, 30, "Female", "Maintain", 1289)]
        public void Calculate_ShouldReturnExpectedValues(double w, double h, int a, string g, string goal, int expected)
        {
            // Act
            var result = CalorieCalculator.Calculate(w, h, a, g, goal);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Calculate_ShouldReturnZero_WhenAgeIsInvalid()
        {
            // Act
            var result = CalorieCalculator.Calculate(70, 170, -5, "Male", "Maintain");

            // Assert
            Assert.Equal(0, result);
        }

        [Theory]
        // Format: Weight, Height, Age, Gender, Goal, Expected 
        [InlineData(70, 170, 25, "Male", "Maintain", 1667)]
        [InlineData(70, 170, 25, "Male", "Lose", 1167)]
        [InlineData(70, 170, 25, "Male", "Gain", 2167)]
        [InlineData(60, 160, 30, "Female", "Maintain", 1332)]
        [InlineData(60, 160, 30, "Female", "Lose", 832)]
        [InlineData(80, 180, 20, "Male", "Maintain", 1865)]
        [InlineData(90, 185, 40, "Male", "Lose", 1430)]
        [InlineData(50, 155, 22, "Female", "Gain", 1750)]
        [InlineData(100, 190, 35, "Male", "Maintain", 2100)]
        [InlineData(65, 165, 28, "Female", "Maintain", 1400)]
        [InlineData(75, 175, 33, "Male", "Lose", 1200)]
        [InlineData(55, 150, 45, "Female", "Gain", 1650)]
        [InlineData(85, 182, 27, "Male", "Maintain", 1920)]
        [InlineData(68, 168, 31, "Female", "Lose", 950)]
        [InlineData(95, 188, 38, "Male", "Gain", 2500)]
        [InlineData(58, 158, 24, "Female", "Maintain", 1380)]
        [InlineData(72, 172, 29, "Male", "Lose", 1250)]
        [InlineData(62, 162, 34, "Female", "Gain", 1850)]
        [InlineData(88, 184, 42, "Male", "Maintain", 1880)]
        [InlineData(52, 152, 21, "Female", "Lose", 800)]
        [InlineData(78, 178, 36, "Male", "Gain", 2300)]
        [InlineData(64, 164, 26, "Female", "Maintain", 1410)]
        [InlineData(82, 181, 32, "Male", "Lose", 1350)]
        [InlineData(56, 156, 41, "Female", "Gain", 1700)]
        [InlineData(74, 174, 23, "Male", "Maintain", 1780)]
        [InlineData(66, 166, 37, "Female", "Lose", 980)]
        [InlineData(92, 186, 44, "Male", "Gain", 2450)]
        [InlineData(54, 154, 19, "Female", "Maintain", 1320)]
        [InlineData(86, 183, 39, "Male", "Lose", 1420)]
        [InlineData(59, 159, 27, "Female", "Gain", 1820)]
        public void Calculate_BulkTests(double w, double h, int a, string ge, string go, int expected)
        {
            var result = CalorieCalculator.Calculate(w, h, a, ge, go);
            Assert.InRange(result, expected - 200, expected + 200);
        }
    }
}