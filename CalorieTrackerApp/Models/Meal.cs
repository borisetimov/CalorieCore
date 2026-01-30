namespace CalorieTrackerApp.Models
{
    public class Meal
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int Calories { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    public string Username { get; set; } = "";
}


}
