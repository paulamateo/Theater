using Theater.Models;
using Theater.Business;
using Microsoft.AspNetCore.Mvc;
using Theater.Data;

namespace Theater.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase {
    private readonly IUserService _userService;

    public UserController (IUserService userService) {
        _userService = userService;
    }

    [HttpGet]
    public ActionResult<List<User>> GetAll() => _userService.GetAllUsers();

    [HttpGet("{userId}")]
    public ActionResult<User> Get(int userId) {
        var user = _userService.GetUserById(userId);

        if(user == null)
            return NotFound();

        return Ok(user);
    }

    [HttpPost]
    public IActionResult Create([FromBody] User user) {            
        _userService.AddUser(user);
        return CreatedAtAction(nameof(Get), new { userId = user.UserId }, user);
    }

    [HttpPut("{userId}")]
    public IActionResult Update(int userId, [FromBody] User user) {
        if (userId != user.UserId)
            return BadRequest();
            
        var existingUser = _userService.GetUserById(userId);
        if(existingUser is null)
            return NotFound();

        existingUser.UserName = user.UserName;
        existingUser.UserLastname = user.UserLastname;
        existingUser.Email = user.Email;
        existingUser.Password = user.Password;
        existingUser.PhoneNumber = user.PhoneNumber;
        existingUser.IsAdmin = user.IsAdmin;
    
        _userService.UpdateUser(existingUser);           
        return NoContent();
    }

    [HttpDelete("{userId}")]
    public IActionResult Delete(int userId) {
        var user = _userService.GetUserById(userId);
    
        if (user is null)
            return NotFound();
        
        _userService.DeleteUser(userId);
    
        return NoContent();
    }

}