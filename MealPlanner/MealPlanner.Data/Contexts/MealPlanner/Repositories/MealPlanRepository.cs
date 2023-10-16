using MealPlanner.Entities;
using Microsoft.EntityFrameworkCore;

namespace MealPlanner.Data.Contexts.MealPlanner.Repositories;

public class MealPlanRepository : IMealPlanRepository
{
    private readonly MealPlannerDbContext _context;

    public MealPlanRepository(MealPlannerDbContext context)
    {
        _context = context;
    }

    public async Task<MealPlan> InsertMealPlan(MealPlan plan)
    {
        _context.MealPlans.Add(plan);
        await _context.SaveChangesAsync();
        return plan;
    }

    public async Task<List<MealPlan>> GetMealPlansForWeek(DateTime startDate)
    {
        var mealPlans = await _context.MealPlans
            .Where(x => x.Date >= startDate && x.Date <= x.Date.AddDays(7))
            .ToListAsync();
        return mealPlans;
    }
}