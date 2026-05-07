using CodeFirst.Data;
using CodeFirst.DTOs;
using CodeFirst.Entities;
using CodeFirst.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Services;

public class DbService : IDbService
{
    private readonly AppDbContext _dbContext;

    public DbService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<UserWithProjectsDto> GetUserWithProjectsById(int id)
    {
        var res = await _dbContext.Users
            .Where(u => u.Id == id)
            .Select(u => new UserWithProjectsDto
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                UserProjects = u.UserProjects.Select(up => new UserProjectDto
                {
                    JoinDate = up.JoinDate,
                    Name = up.Project.Name
                })
            }).FirstOrDefaultAsync();
        
        if (res == null)
        {
            throw new NotFoundException();
        }
        
        return res;
    }

    public async Task AddUserAsync(AddUserDto userDto)
    {
        var user = new User()
        {
            FirstName = userDto.FirstName,
            LastName = userDto.LastName,
        };
        await _dbContext.AddAsync(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateUserAsync(int id, UpdateUserDto userDto)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(e => e.Id == id);
        if (user == null)
        {
            throw new NotFoundException();
        }
        
        user.FirstName = userDto.FirstName;
        user.LastName = userDto.LastName;
        await _dbContext.SaveChangesAsync();
    }

    public async Task RemoveUserByIdAsync(int id)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(e => e.Id == id);
        if (user == null)
        {
            throw new NotFoundException();
        }
        
        _dbContext.Users.Remove(user);
        await _dbContext.SaveChangesAsync();

        return;
        
        // Create a user entity with only the Id populated
        // This avoids loading the full entity from the database
        var userWithId = new User() { Id = 1 };
        _dbContext.Users.Attach(userWithId);
        _dbContext.Users.Remove(userWithId);
        var affectedRows = await _dbContext.SaveChangesAsync();
        if (affectedRows == 0)
        {
            throw new NotFoundException();
        }
        
        // Delete the user directly in the database without loading it into memory
        // ExecuteDeleteAsync generates a SQL DELETE statement
        var affectedRows2 = await _dbContext.Users.Where(e => e.Id == id).ExecuteDeleteAsync();
        if (affectedRows2 == 0)
        {
            throw new NotFoundException();
        }
    }
}