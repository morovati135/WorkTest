using Application.Dto;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("All")]
    public async Task<ActionResult<IReadOnlyList<UserDto>>> GetAll()
    {
        var users = await _userService.GetAllUsers();
        return Ok(users);
    }

    [HttpGet("FindById/{id}")]
    public async Task<ActionResult<UserDto>> GetById(int id)
    {
        var user = await _userService.GetUserById(id);
        if (user == null)
            return NotFound();

        return Ok(user);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<UserDto>> Create(CreateUserDto createUserDto)
    {
        var user = await _userService.CreateUser(createUserDto);
        return CreatedAtAction(nameof(GetById), new { id = user.UserId }, user);
    }

    [HttpPut("Update/{id}")]
    public async Task<IActionResult> Update(int id, UpdateUserDto updateUserDto)
    {
        try
        {
            await _userService.UpdateUser(id, updateUserDto);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _userService.DeleteUser(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
    
    [HttpGet("{id}/AllUserProducts")]
    public async Task<IActionResult> GetUserProducts(int id)
    {
        var products = await _userService.GetUserProducts(id);
        if (products == null || !products.Any())
            return NotFound();

        return Ok(products);
    }
}