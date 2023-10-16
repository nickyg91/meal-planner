using MealPlanner.Entities;

namespace MealPlanner.Data.Contexts.MealPlanner.Repositories;

public interface IMealRepository
{
    Task<Meal> InsertMeal(Meal meal);
    Task<Meal?> GetMealById(int id);
    Task<List<Meal?>> GetAllMeals();
}