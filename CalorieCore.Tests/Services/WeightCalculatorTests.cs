using Xunit;
using CalorieCore.Services;

namespace CalorieCore.Tests
{
    public class WeightCalculatorTests
    {
        [Theory]
        [InlineData(70, 178, 25, 22.1, "Normal weight")] // Standard Normal
        [InlineData(50, 178, 25, 15.8, "Underweight")]   // Standard Underweight
        [InlineData(80, 178, 25, 25.2, "Overweight")]    // Standard Overweight
        [InlineData(110, 178, 25, 34.7, "Obese")]        // Standard Obese
        public void Analyze_ShouldReturnCorrectBmiAndCategory(double weight, double height, int age, double expectedBmi, string expectedCategory)
        {
            // Act
            var result = WeightCalculator.Analyze(weight, height, age);

            // Assert
            Assert.Equal(expectedBmi, result.BMI);
            Assert.Equal(expectedCategory, result.Category);
        }

        [Fact]
        public void Analyze_ShouldCalculateCorrectHealthyRange_For178cm()
        {
            // Arrange
            double height = 178; // cm

            // Act
            var result = WeightCalculator.Analyze(70, height, 30);
            // Min: 18.5 * (1.78 * 1.78) = 58.6
            // Max: 24.9 * (1.78 * 1.78) = 78.9
            Assert.Equal(58.6, result.MinNormalWeight);
            Assert.Equal(78.9, result.MaxNormalWeight);
        }

        [Fact]
        public void Analyze_ShouldReturnMessage_WhenHeightIsZero()
        {
            // Act
            var result = WeightCalculator.Analyze(70, 0, 25);

            // Assert
            Assert.Equal("Height required for BMI calculation.", result.Message);
        }

        [Fact]
        public void GetAdvice_ShouldGiveSpecialAdvice_ForSeniorsUnderweight()
        {
            // Act: 70 years old and underweight
            var result = WeightCalculator.Analyze(45, 170, 70);

            // Assert
            Assert.Contains("maintaining a bit more weight is often safer", result.Message);
        }
    }
}