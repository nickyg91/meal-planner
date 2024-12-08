using MealPlanner.Data.Contexts.MealPlanner.Entities.Families;
using MealPlanner.Entities.Enums;

namespace MealPlanner.Data.Contexts.MealPlanner.Entities.Meals;

public class MealIngredient : BaseEntity
{
    public int FamilyMealId { get; set; }
    public FamilyMeal FamilyMeal { get; set; }
    public required string IngredientName { get; set; }
    public required decimal Quantity { get; set; }
    public MeasurementType? MeasurementType { get; set; }
}