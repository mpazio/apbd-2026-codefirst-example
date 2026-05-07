using CodeFirst.DTOs;
using CodeFirst.Exceptions;
using CodeFirst.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirst.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IDbService _dbService;

    public UsersController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [Route("{id}/projects")]
    [HttpGet]
    public async Task<IActionResult> GetUserProjectsById(int id)
    {
        try
        {
            var res = await _dbService.GetUserWithProjectsById(id);
            return Ok(res);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> AddUser(AddUserDto user)
    {
        await _dbService.AddUserAsync(user);
        return Created();   
    }
    
    [Route("{id}")]
    [HttpPut]
    public async Task<IActionResult> UpdateUser(int id, UpdateUserDto user)
    {
        try
        {
            await _dbService.UpdateUserAsync(id, user);
            return NoContent();   
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        } 
    }

    [Route("{id}")]
    [HttpDelete]
    public async Task<IActionResult> RemoveUser(int id)
    {
        try
        {
            await _dbService.RemoveUserByIdAsync(id);
            return NoContent();   
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
}