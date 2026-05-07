namespace CodeFirst.DTOs;

public class UserWithProjectsDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public IEnumerable<UserProjectDto> UserProjects { get; set; } = [];
}

public class UserProjectDto
{
    public string Name { get; set; } = string.Empty;
    public DateTime JoinDate { get; set; }
}