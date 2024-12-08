using MealPlanner.Entities.Families;

namespace MealPlanner.Entities.Meals;

public class MealPlan : BaseEntity
{
    public required DateTime MealPlanStartDate { get; set; }
    public required DateTime MealPlanEndDate { get; set; }
    public required string MealPlanName { get; set; }
    public int FamilyId { get; set; }
    public Family Family { get; set; }
}