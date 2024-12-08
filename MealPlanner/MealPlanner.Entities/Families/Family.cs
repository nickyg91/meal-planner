namespace MealPlanner.Entities.Families;

public class Family : BaseEntity
{
    public required string FamilyName { get; set; }
    public List<FamilyMember> FamilyMembers { get; set; } = [];
}