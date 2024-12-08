using MealPlanner.Data.Contexts.MealPlanner.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MealPlanner.Data.Contexts.MealPlanner.EntityConfigurations;

public class UserEntityTypeConfiguration : BaseEntityConfiguration<User>
{
    public override string TableName => "user";
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);

        builder
            .Property(x => x.Email)
            .HasColumnName("email")
            .HasMaxLength(64)
            .IsRequired();

        builder
            .Property(x => x.Password)
            .HasColumnName("email")
            .HasMaxLength(512)
            .IsRequired();
    }
}