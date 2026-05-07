using CodeFirst.DTOs;
using CodeFirst.Entities;

namespace CodeFirst.Services;

public interface IDbService
{
    Task<UserWithProjectsDto> GetUserWithProjectsById(int id);
    Task AddUserAsync(AddUserDto userDto);
    Task UpdateUserAsync(int id, UpdateUserDto userDto);
    Task RemoveUserByIdAsync(int id);
}