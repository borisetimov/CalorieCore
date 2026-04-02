public static class CalorieCalculator
{
    public static int Calculate(double weight, double height, int age, string gender, string goal)
    {
        if (age <= 0 || weight <= 0 || height <= 0) return 0;

        double bmr;
        if (gender?.ToLower() == "male")
        {
            bmr = (10 * weight) + (6.25 * height) - (5 * age) + 5;
        }
        else
        {
            bmr = (10 * weight) + (6.25 * height) - (5 * age) - 161;
        }

        if (goal == "Lose") bmr -= 500;
        if (goal == "Gain") bmr += 500;

        return (int)bmr;
    }
}