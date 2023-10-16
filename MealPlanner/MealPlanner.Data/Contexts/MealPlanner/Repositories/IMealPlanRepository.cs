using MealPlanner.Entities;

namespace MealPlanner.Data.Contexts.MealPlanner.Repositories;

public interface IMealPlanRepository
{
    Task<MealPlan> InsertMealPlan(MealPlan plan);
    Task<List<MealPlan>> GetMealPlansForWeek(DateTime startDate);
}