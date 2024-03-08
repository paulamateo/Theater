using Theater.Models;
using Theater.Business;
using Microsoft.AspNetCore.Mvc;

namespace Theater.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase {
    private readonly IUserService _userService;

    public UserController (IUserService userService) {
        _userService = userService;
    }


    [HttpGet]
    public ActionResult<List<User>> GetAll() =>
        _userService.GetAllUsers();

    [HttpGet("{userId}")]
    public ActionResult<User> Get(int userId) {
        var user = _userService.GetUserById(userId);

        if(user == null)
            return NotFound();

        return user;
    }

    [HttpPost]
    public IActionResult Create(User user) {            
        _userService.AddUser(user);
        return CreatedAtAction(nameof(Get), new { userId = user.UserId }, user);
    }

    [HttpPut("{userId}")]
    public IActionResult Update(int userId, User user) {
        if (userId != user.UserId)
            return BadRequest();
            
        var existingUser = _userService.GetUserById(userId);
        if(existingUser is null)
            return NotFound();
    
        _userService.UpdateUser(user);           
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