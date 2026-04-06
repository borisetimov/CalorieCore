using Xunit;
using CalorieCore.Services;

namespace CalorieCore.Tests
{
    public class WeightCalculatorTests
    {
        [Theory]
        [InlineData(70, 178, 25, 22.1, "Normal weight")] // Standard Normal
        [InlineData(55, 180, 30, 17.0, "Underweight")]   // Standard Underweight
        [InlineData(95, 180, 30, 29.3, "Overweight")]    // Standard Overweight
        [InlineData(110, 175, 30, 35.9, "Obese")]         // Standard Obese
        public void Analyze_ShouldReturnCorrectBmiAndCategory(double weight, double height, int age, double expectedBmi, string expectedCategory)
        {
            // Act
            var result = WeightCalculator.Analyze(weight, height, age);

            // Assert
            Assert.Equal(expectedBmi, result.BMI);
            Assert.Equal(expectedCategory, result.Category);
        }

        [Fact]
        public void Analyze_ShouldProduceCorrectColorClasses()
        {
            var underweight = WeightCalculator.Analyze(50, 180, 25);
            var normal = WeightCalculator.Analyze(70, 180, 25);
            var overweight = WeightCalculator.Analyze(95, 180, 25);
            var obese = WeightCalculator.Analyze(120, 180, 25);

            Assert.Equal("underweight", underweight.Color);
            Assert.Equal("normal", normal.Color);
            Assert.Equal("overweight", overweight.Color);
            Assert.Equal("obese", obese.Color);
        }

        [Fact]
        public void Analyze_HeightZero_ReturnsRequiredMessage()
        {
            // Act
            var result = WeightCalculator.Analyze(70, 0, 25);

            // Assert
            Assert.Equal("Height required for BMI calculation.", result.Message);
        }

        [Fact]
        public void GetAdvice_NormalWeight_ReturnsSuccessMessage()
        {
            // Act
            var result = WeightCalculator.Analyze(70, 178, 30);

            // Assert
            Assert.Equal("You are within the healthy norm!", result.Message);
        }

        [Fact]
        public void GetAdvice_SeniorsUnderweight_ReturnsSpecialAdvice()
        {
            // Act
            var result = WeightCalculator.Analyze(50, 180, 70);

            // Assert
            Assert.Contains("maintaining a bit more weight is often safer", result.Message);
        }

        [Fact]
        public void Analyze_CalculatesCorrectNormalRange()
        {
            // Height: 180cm -> 1.8m
            // Min: 18.5 * (1.8 * 1.8) = 59.94 -> Rounded to 59.9
            // Max: 24.9 * (1.8 * 1.8) = 80.67 -> Rounded to 80.7

            var result = WeightCalculator.Analyze(70, 180, 30);

            Assert.Equal(59.9, result.MinNormalWeight);
            Assert.Equal(80.7, result.MaxNormalWeight);
        }

        [Fact]
        public void Analyze_BoundaryBmi_CategorizesCorrecty()
        {
            // Testing the exact boundary of 24.9/25.0
            // Weight 81kg at 180cm height = ~25.0 BMI
            var result = WeightCalculator.Analyze(81, 180, 25);

            Assert.Equal("Overweight", result.Category);
        }
    }
}