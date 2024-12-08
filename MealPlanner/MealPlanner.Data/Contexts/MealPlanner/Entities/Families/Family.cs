using MealPlanner.Data.Contexts.MealPlanner.Entities.Meals;

namespace MealPlanner.Data.Contexts.MealPlanner.Entities.Families;

public class Family : BaseEntity
{
    public required string FamilyName { get; set; }
    public List<FamilyMember> FamilyMembers { get; set; } = [];
    public List<FamilyMeal> FamilyMeals { get; set; } = [];
    public List<MealPlan> MealPlans { get; set; } = [];
}