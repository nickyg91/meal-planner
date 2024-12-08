using MealPlanner.Data.Contexts.MealPlanner.Entities.Families;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MealPlanner.Data.Contexts.MealPlanner.EntityConfigurations;

public class FamilyEntityTypeConfiguration : BaseEntityConfiguration<Family>
{
    public override string TableName => "family";
    
    public override void Configure(EntityTypeBuilder<Family> builder)
    {
        base.Configure(builder);
        
        builder.Property(f => f.FamilyName)
            .IsRequired()
            .HasMaxLength(64);
        
        builder.HasMany(f => f.FamilyMembers)
            .WithOne(fm => fm.Family)
            .HasForeignKey(fm => fm.FamilyId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}