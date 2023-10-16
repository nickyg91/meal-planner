using MealPlanner.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MealPlanner.Data.Contexts.EntityConfigurations;

public class MealPlanEntityConfiguration : IEntityTypeConfiguration<MealPlan>
{
    public void Configure(EntityTypeBuilder<MealPlan> builder)
    {
        builder.ToTable("meal_plan");
        builder.Property(x => x.Id)
            .IsRequired()
            .HasColumnName("id")
            .UseIdentityColumn();
        builder.HasKey(x => x.Id).HasName("pk_meal_plan");
        builder.Property(x => x.Date).IsRequired().HasColumnName("meal_date");

        builder.HasOne(x => x.Meal).WithOne().HasConstraintName("fk_meal_plan_meal");
    }
}