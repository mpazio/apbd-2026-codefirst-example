using CodeFirst.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeFirst.Configurations;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Name).HasMaxLength(100);
        builder.Property(p => p.Budget).HasColumnType("decimal(10,2)");
        
        builder.ToTable("Projects");
        
        builder.HasData(new List<Project>()
        {
            new Project() { Id = 1, Name = "Project 1", Budget = 1000.0m},
            new Project() { Id = 2, Name = "Project 2", Budget = 14000.0m},
        });
    }
}