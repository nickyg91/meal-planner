using MealPlanner.Data.Contexts.MealPlanner.Entities.Families;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MealPlanner.Data.Contexts.MealPlanner.EntityConfigurations;

public class FamilyMemberEntityTypeConfiguration : BaseEntityConfiguration<FamilyMember>
{
    public override string TableName => "family_member";
    public override void Configure(EntityTypeBuilder<FamilyMember> builder)
    {
        base.Configure(builder);

        builder
            .Property(x => x.FamilyId)
            .HasColumnName("family_id");

        builder
            .Property(x => x.UserId)
            .IsRequired()
            .HasColumnName("user_id");

        builder
            .HasIndex(x => x.UserId)
            .IsUnique()
            .HasDatabaseName("ix_family_member_user_id");
        
        builder
            .HasOne(x => x.User)
            .WithOne()
            .HasConstraintName("fk_family_member_user");
        
        builder
            .HasOne(x => x.Family)
            .WithMany(x => x.FamilyMembers)
            .HasForeignKey(x => x.FamilyId)
            .HasConstraintName("fk_family_member_family")
            .IsRequired();
    }
}