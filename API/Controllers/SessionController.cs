using Theater.Models;
using Theater.Business;
using Microsoft.AspNetCore.Mvc;

namespace Theater.Controllers;

[ApiController]
[Route("[controller]")]
public class SessionController : ControllerBase {
    private readonly ISessionService _sessionService;

    public SessionController (ISessionService sessionService) {
        _sessionService = sessionService;
    }

    [HttpGet()]
    public ActionResult<List<Session>> GetAllSessions() =>
        _sessionService.GetAllSessions();
    
    [HttpGet("{sessionId}")]
    public ActionResult<Session> GetSession(int sessionId) {
        var session = _sessionService.GetSessionById(sessionId);

        if(session == null)
            return NotFound();

        return session;
    }
    
    [HttpPost()]
    public IActionResult CreateSession(SessionCreateDTO session) {            
        _sessionService.AddSession(session);
        return CreatedAtAction(nameof(GetSession), new { sessionId = session.SessionId }, session);
    }
}