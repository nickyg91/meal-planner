using MealPlanner.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MealPlanner.Data.Contexts.EntityConfigurations;

public class MealEntityConfiguration : IEntityTypeConfiguration<Meal>
{
    public void Configure(EntityTypeBuilder<Meal> builder)
    {
        builder.ToTable("meal");
        builder.Property(x => x.Id)
            .IsRequired()
            .HasColumnName("id")
            .UseIdentityColumn();
        builder.HasKey(x => x.Id).HasName("pk_meal");

        builder.Property(x => x.Name).IsRequired().HasMaxLength(256).HasColumnName("name");
    }
}