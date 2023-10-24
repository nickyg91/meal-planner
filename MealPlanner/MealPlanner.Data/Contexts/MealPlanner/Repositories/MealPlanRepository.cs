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

    public async Task<List<MealPlan>> InsertMealPlan(List<MealPlan> plans)
    {
        await _context.MealPlans.AddRangeAsync(plans);
        await _context.SaveChangesAsync();
        return plans;
    }

    public async Task<List<MealPlan>> GetMealPlansForWeek(DateTime startDate)
    {
        var mealPlans = await _context.MealPlans
            .Where(x => x.Date >= startDate && x.Date <= x.Date.AddDays(7))
            .ToListAsync();
        return mealPlans;
    }
}