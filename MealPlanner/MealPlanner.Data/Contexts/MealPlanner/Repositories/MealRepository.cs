using MealPlanner.Entities;
using Microsoft.EntityFrameworkCore;

namespace MealPlanner.Data.Contexts.MealPlanner.Repositories;

public class MealRepository : IMealRepository
{
    private readonly MealPlannerDbContext _context;

    public MealRepository(MealPlannerDbContext context)
    {
        _context = context;
    }

    public async Task<Meal> InsertMeal(Meal meal)
    {
        _context.Meals.Add(meal);
        await _context.SaveChangesAsync();
        return meal;
    }

    public async Task<Meal?> GetMealById(int id)
    {
        return await _context.Meals.FindAsync(id);
    }

    public async Task<List<Meal?>> GetAllMeals()
    {
        return await _context.Meals.AsQueryable().ToListAsync();
    }
}