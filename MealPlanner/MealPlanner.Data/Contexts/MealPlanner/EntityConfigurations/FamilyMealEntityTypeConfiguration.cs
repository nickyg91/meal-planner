using MealPlanner.Data.Contexts.MealPlanner.Entities.Families;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MealPlanner.Data.Contexts.MealPlanner.EntityConfigurations;

public class FamilyMealEntityTypeConfiguration : BaseEntityConfiguration<FamilyMeal>
{
    public override string TableName => "family_meal";
    public override void Configure(EntityTypeBuilder<FamilyMeal> builder)
    {
        base.Configure(builder);

        builder
            .Property(x => x.FamilyId)
            .HasColumnName("family_id")
            .IsRequired();

        builder
            .Property(x => x.RecipeUrl)
            .HasMaxLength(256)
            .HasColumnName("recipe_url");
        
        builder
            .Property(x => x.RecipeDescription)
            .HasColumnName("recipe_description");
        
        builder
            .Property(x => x.MealName)
            .IsRequired()
            .HasMaxLength(32)
            .HasColumnName("meal_name");

        builder
            .HasOne(x => x.Family)
            .WithMany(x => x.FamilyMeals)
            .HasForeignKey(x => x.FamilyId);

        builder
            .HasOne(x => x.Family)
            .WithMany(x => x.FamilyMeals)
            .HasForeignKey(x => x.FamilyId)
            .HasConstraintName("fk_family_meal_family_id");
    }
}