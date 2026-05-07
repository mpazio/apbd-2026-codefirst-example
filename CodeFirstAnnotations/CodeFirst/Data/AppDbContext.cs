using CodeFirst.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Data;

public class AppDbContext : DbContext
{
    protected AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<UserProject> UserProjects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(new List<User>()
        {
            new User() { Id = 1, FirstName = "Jan", LastName = "Kowalski"},
            new User() { Id = 2, FirstName = "John", LastName = "Doe"},
            new User() { Id = 3, FirstName = "Jane", LastName = "Doe"},
        });

        modelBuilder.Entity<Project>().HasData(new List<Project>()
        {
            new Project() { Id = 1, Name = "Project 1", Budget = 1000.0m},
            new Project() { Id = 2, Name = "Project 2", Budget = 14000.0m},
        });

        modelBuilder.Entity<UserProject>().HasData(new List<UserProject>()
        {
            new UserProject() { UserId = 1, ProjectId = 1, JoinDate = DateTime.Parse("2026-05-07")},
            new UserProject() { UserId = 1, ProjectId = 2, JoinDate = DateTime.Parse("2026-05-07")},
            new UserProject() { UserId = 2, ProjectId = 1, JoinDate = DateTime.Parse("2026-05-07")}
        });
        
        base.OnModelCreating(modelBuilder);
    }
}