namespace CodeFirst.Entities;

public class UserProject
{
    public int UserId { get; set; }
    public int ProjectId { get; set; }
    public DateTime JoinDate { get; set; }
    
    public User User { get; set; } = null!;
    public Project Project { get; set; } = null!;
}