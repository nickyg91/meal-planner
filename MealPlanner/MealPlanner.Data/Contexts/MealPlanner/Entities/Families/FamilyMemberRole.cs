using MealPlanner.Entities.Enums;

namespace MealPlanner.Data.Contexts.MealPlanner.Entities.Families;

public class FamilyMemberRole : BaseEntity
{
    public FamilyMemberRoleType RoleTypeId { get; set; }
    public int FamilyMemberId { get; set; }
    public FamilyMember FamilyMember { get; set; }
}