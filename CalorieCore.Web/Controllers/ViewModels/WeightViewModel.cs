using CalorieCore.DataModels; 
using CalorieCore.Services;

namespace CalorieCore.Web.ViewModels
{
    public class WeightViewModel
    {
        public List<WeightLog> Logs { get; set; } = new List<WeightLog>();
        public WeightStatus? Status { get; set; }
        public double Height { get; set; }
        public double CurrentWeight { get; set; }
        public double NewWeightEntry { get; set; }
    }
}