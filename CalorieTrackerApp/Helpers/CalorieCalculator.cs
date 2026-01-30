public static class CalorieCalculator
{
    public static int Calculate(double weight, double height, int age, string goal)
    {
        double bmr = 10 * weight + 6.25 * height - 5 * age + 5;

        if (goal == "Lose") bmr -= 500;
        if (goal == "Gain") bmr += 500;

        return (int)bmr;
    }
}
