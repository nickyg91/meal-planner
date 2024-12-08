using MealPlanner.Data.Contexts.MealPlanner.Entities.Families;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MealPlanner.Data.Contexts.MealPlanner.EntityConfigurations;

public class FamilyMemberRoleEntityTypeConfiguration : BaseEntityConfiguration<FamilyMemberRole>
{
    public override string TableName => "family_member_role";
    
    public override void Configure(EntityTypeBuilder<FamilyMemberRole> builder)
    {
        base.Configure(builder);

        builder
            .Property(x => x.RoleTypeId)
            .HasColumnName("role_type_id")
            .IsRequired();

        builder
            .Property(x => x.FamilyMemberId)
            .HasColumnName("family_member_id")
            .IsRequired();

        builder
            .HasOne(x => x.FamilyMember)
            .WithOne(x => x.FamilyMemberRole)
            .HasConstraintName("fk_family_member_role_family_member");
    }
}