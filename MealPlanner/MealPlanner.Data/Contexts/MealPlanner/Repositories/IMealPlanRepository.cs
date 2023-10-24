using MealPlanner.Entities;

namespace MealPlanner.Data.Contexts.MealPlanner.Repositories;

public interface IMealPlanRepository
{
    Task<List<MealPlan>> InsertMealPlan(List<MealPlan> plans);
    Task<List<MealPlan>> GetMealPlansForWeek(DateTime startDate);
}