using MealPlanner.Data.Contexts.EntityConfigurations;
using MealPlanner.Entities;
using Microsoft.EntityFrameworkCore;

namespace MealPlanner.Data.Contexts.MealPlanner;

public class MealPlannerDbContext : DbContext
{
    public DbSet<Meal?> Meals { get; set; }
    public DbSet<MealPlan> MealPlans { get; set; }
    
    public MealPlannerDbContext(DbContextOptions<MealPlannerDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("mealplanner");
        var mealEntityConfiguration = new MealEntityConfiguration();
        mealEntityConfiguration.Configure(modelBuilder.Entity<Meal>());
        var mealPlanEntityConfiguration = new MealPlanEntityConfiguration();
        mealPlanEntityConfiguration.Configure(modelBuilder.Entity<MealPlan>());
        base.OnModelCreating(modelBuilder);
    }
}