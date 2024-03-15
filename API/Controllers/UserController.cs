using Theater.Models;
using Theater.Business;
using Theater.Logging;
using Microsoft.AspNetCore.Mvc;

namespace Theater.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase {
    private readonly IUserService _userService;
    private readonly ILogMethod _logMethod;

    public UserController (IUserService userService, ILogMethod logMethod) {
        _userService = userService;
        _logMethod = logMethod;
    }

    [HttpGet]
    public ActionResult<List<User>> GetAll() {
        try {
            return _userService.GetAllUsers();
        }catch (Exception ex) {
            _logMethod.LogError(ex, "Error listing users");
            return StatusCode(500);
        }
    }

    [HttpGet("{userId}")]
    public ActionResult<User> Get(int userId) {
        try {
            var user = _userService.GetUserById(userId);
            if (user == null) {
                _logMethod.LogError(new Exception("User not found"), $"Error getting user with ID {userId}");
                return NotFound();
            }
            return Ok(user);
        }catch (Exception ex) {
            _logMethod.LogError(ex, "Error getting user with ID {userId}");
            return StatusCode(500);
        }
    }

    [HttpPost]
    public IActionResult Create([FromBody] User user) {  
        try {
            if (!ModelState.IsValid) {
                _logMethod.LogError(new Exception("Unable to create user"), $"Error creating the user");
                return BadRequest(ModelState);
            } 
            _userService.AddUser(user);
            return CreatedAtAction(nameof(Get), new { userId = user.UserId }, user);
        }catch (Exception ex) {
            _logMethod.LogError(ex, "Error creating the user");
            return StatusCode(500);
        }       
    }

    [HttpPut("{userId}")]
    public IActionResult Update(int userId, [FromBody] User user) {
        try {
            if (userId != user.UserId) {
                _logMethod.LogError(new Exception("Unable to update user"), $"Error updating user with ID {userId}");
                return BadRequest();
            }
            var existingUser = _userService.GetUserById(userId);
            if(existingUser is null) {
                _logMethod.LogError(new Exception("User not found"), $"Error updating user with ID {userId}");
                return NotFound();
            }
            existingUser.UserName = user.UserName;
            existingUser.UserLastname = user.UserLastname;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;
            existingUser.PhoneNumber = user.PhoneNumber;
            existingUser.IsAdmin = user.IsAdmin;
            _userService.UpdateUser(existingUser);           
            return Ok();
        }catch (Exception ex) {
            _logMethod.LogError(ex, "Error updating the user");
            return StatusCode(500);
        }
    }

    [HttpDelete("{userId}")]
    public IActionResult Delete(int userId) {
        try {
            var user = _userService.GetUserById(userId);
            if (user is null) {
                _logMethod.LogError(new Exception("User not found"), $"Error deleting user with ID {userId}");
                return NotFound();
            }
            _userService.DeleteUser(userId);
            return Ok();
        }catch (Exception ex) {
            _logMethod.LogError(ex, "Error deleting the user");
            return StatusCode(500);
        }
    }

}