using Appointment.Data.Dtos;
using Appointment.Data.Entities;
using Appointment.Data.Models.Account;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserService _userService;

    public UserController(ILogger<UserController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<List<User>>> GetUser()
    {
        return Ok(await _userService.GetAll());
    }

    [HttpGet]
    [Route("/GetUser/{id}")]
    public async Task<ActionResult<User>> GetUserById(int id)
    {
        var user = await _userService.GetById(id);

        if (user == null)
        {
            _logger.LogInformation($"User with id {id} not found.");
            return NotFound();
        }

        _logger.LogInformation($"Got user {user.Name} {user.Surname}");

        return Ok(user);
    }

    [HttpPost]
    [Route("/CreateUser")]
    public async Task<ActionResult<User>> PostUser(AddUserDto user)
    {
        await _userService.Create(user);   

        _logger.LogInformation($"Added user {user.FirstName} {user.LastName}");

        return Ok();
    }

    [HttpPost]
    [Route("/AuthenticateUser")]
    public ActionResult<AuthenticateUserResponseDto> AuthenticateUser(AuthenticateUserDto user)
    {
        var authenticatedUser = _userService.Authenticate(user);

        _logger.LogInformation("User logged in");

        return Ok(authenticatedUser);
    }

    [HttpPut]
    [Route("/UpdateUser/{id}")]
    public async Task<ActionResult<User>> PutUser(UserDto user, int id)
    {
        await _userService.UpdateById(id, user);

        return Ok();
    }

    [HttpDelete]
    [Route("/DeleteUser/{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        await _userService.DeleteById(id);

        return Ok();
    }
}