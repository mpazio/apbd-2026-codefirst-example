using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Entities;

[PrimaryKey(nameof(UserId), nameof(ProjectId))]
public class UserProject
{
    public int UserId { get; set; }
    public int ProjectId { get; set; }
    [Column(TypeName = "date")]
    public DateTime JoinDate { get; set; }

    [ForeignKey(nameof(UserId))]
    public User User { get; set; } = null!;
    [ForeignKey(nameof(ProjectId))]
    public Project Project { get; set; } = null!;
}