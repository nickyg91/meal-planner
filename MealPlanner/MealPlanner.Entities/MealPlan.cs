namespace MealPlanner.Entities;

public class MealPlan
{
    public int Id { get; set; }
    public Meal Meal { get; set; }
    public int MealId { get; set; }
    public DateTime Date { get; set; }
}