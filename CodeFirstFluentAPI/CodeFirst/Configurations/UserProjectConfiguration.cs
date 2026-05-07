using CodeFirst.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeFirst.Configurations;

public class UserProjectConfiguration : IEntityTypeConfiguration<UserProject>
{
    public void Configure(EntityTypeBuilder<UserProject> builder)
    {
        builder.HasKey(p => new { p.UserId, p.ProjectId });
        builder.Property(p => p.JoinDate).HasColumnType("date");
        
        builder.HasOne(p => p.User)
            .WithMany(u => u.UserProjects)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(p => p.Project)
            .WithMany(p => p.UserProjects)
            .HasForeignKey(p => p.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasData(new List<UserProject>()
        {
            new UserProject() { UserId = 1, ProjectId = 1, JoinDate = DateTime.Parse("2026-05-07")},
            new UserProject() { UserId = 1, ProjectId = 2, JoinDate = DateTime.Parse("2026-05-07")},
            new UserProject() { UserId = 2, ProjectId = 1, JoinDate = DateTime.Parse("2026-05-07")}
        });
    }
}