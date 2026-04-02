using CalorieCore.DataModels;

namespace CalorieCore.Services
{
    public interface IWeightService
    {
        Task<List<WeightLog>> GetChartDataAsync(string userId);
        Task<bool> LogWeightAsync(string userId, double weight);
        Task<bool> DeleteLogAsync(int id, string userId);
    }
}