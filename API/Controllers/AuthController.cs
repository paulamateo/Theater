using Theater.Models;
using Theater.Business;
using Microsoft.AspNetCore.Mvc;

namespace Theater.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase {
    private readonly IUserService _userService;
    private readonly ILogger<AuthController> _logger;

    public AuthController (ILogger<AuthController> logger, IUserService userService) {
        _logger = logger;
        _userService = userService;
    }

    [HttpPost("Register")]
    public IActionResult Create([FromBody] User user) {   
        var Get = _userService.GetUserById(user.UserId);         
        _userService.AddUser(user);
        return CreatedAtAction(nameof(Get), new { userId = user.UserId }, user);
    }

    [HttpPost("Login")]
    public ActionResult<User> Login([FromBody] UserLoginDTO loginDto) {
        var user = _userService.Login(loginDto.Email, loginDto.Password);

        if (user == null) {
            return Unauthorized();
        }

        return Ok(user);
    }

}