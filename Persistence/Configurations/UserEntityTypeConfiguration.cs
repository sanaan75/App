using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        // builder.Property(i => i.Name).IsRequired();
        // builder.HasIndex(i => i.Name).IsUnique();
        // builder.HasIndex(i => i.Id);
    }
}