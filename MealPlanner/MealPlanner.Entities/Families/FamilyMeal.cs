using MealPlanner.Entities.Enums;

namespace MealPlanner.Entities.Families;

public class FamilyMeal : BaseEntity
{
    public required string MealName { get; set; }
    public int FamilyId { get; set; }
    public Family Family { get; set; }
    public string? RecipeUrl { get; set; }
    public required MealType MealType { get; set; }
}