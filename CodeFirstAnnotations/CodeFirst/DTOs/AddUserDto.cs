using System.ComponentModel.DataAnnotations;

namespace CodeFirst.DTOs;

public class AddUserDto
{
    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;
}
