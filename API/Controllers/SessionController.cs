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
}