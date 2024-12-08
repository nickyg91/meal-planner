using MealPlanner.Entities.Enums;
using MealPlanner.Entities.Families;

namespace MealPlanner.Entities.Meals;

public class MealIngredient : BaseEntity
{
    public int FamilyMealId { get; set; }
    public FamilyMeal FamilyMeal { get; set; }
    public required string IngredientName { get; set; }
    public required decimal Quantity { get; set; }
    public MeasurementType? MeasurementType { get; set; }
}