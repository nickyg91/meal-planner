namespace MealPlanner.Data.Contexts.MealPlanner.Entities.Meals;

public class MealPlanMeal : BaseEntity
{
    public int MealPlanId { get; set; }
    public MealPlan MealPlan { get; set; }
    public DateTime MealDateTimeUtc { get; set; }
}