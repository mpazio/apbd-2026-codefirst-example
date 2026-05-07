using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst.Entities;

[Table("Projects")]
public class Project
{
    [Key]
    public int Id { get; set; }
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    [Column(TypeName = "decimal(10,2)")]
    public decimal Budget { get; set; }
    
    public ICollection<UserProject> UserProjects { get; set; } = [];
}