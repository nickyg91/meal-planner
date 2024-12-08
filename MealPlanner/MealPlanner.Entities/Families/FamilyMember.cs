namespace MealPlanner.Entities.Families;

public class FamilyMember : BaseEntity
{
    public int UserId { get; set; }
    public int FamilyId { get; set; }
    public required Family Family { get; set; }
    public required User User { get; set; }
}