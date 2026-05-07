using CodeFirst.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeFirst.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.FirstName).HasMaxLength(50);
        builder.Property(x => x.LastName).HasMaxLength(100);
        
        builder.ToTable("Users");
        
        builder.HasData(new List<User>()
        {
            new User() { Id = 1, FirstName = "Jan", LastName = "Kowalski"},
            new User() { Id = 2, FirstName = "John", LastName = "Doe"},
            new User() { Id = 3, FirstName = "Jane", LastName = "Doe"},
        });
    }
}