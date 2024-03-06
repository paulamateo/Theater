using Theater.Models;
using Theater.Business;
using Microsoft.AspNetCore.Mvc;

namespace Theater.Controllers;

[ApiController]
[Route("[controller]")]
public class ShowController : ControllerBase {
    private readonly IShowService _showService;

    public ShowController (IShowService showService) {
        _showService = showService;
    }

    [HttpGet("/Sessions")]
    public ActionResult<List<Session>> GetAllSessions() =>
        _showService.GetAllSessions();
    
    [HttpGet("{showId}/Session")]
    public ActionResult<List<Session>> GetSessionsByShowId(int showId) =>
        _showService.GetSessionsByShowId(showId);




    //SHOWS
    [HttpGet()]
    public ActionResult<List<Show>> GetAll() =>
        _showService.GetAllShows();

    [HttpGet("{showId}")]
    public ActionResult<Show> Get(int showId) {
        var show = _showService.GetShowById(showId);

        if(show == null)
            return NotFound();

        return show;
    }

    [HttpPost()]
    public IActionResult Create(Show show) {            
        _showService.AddShow(show);
        return CreatedAtAction(nameof(Get), new { showId = show.ShowId }, show);
    }

    [HttpPut("{showId}")]
    public IActionResult Update(int showId, Show show) {
        if (showId != show.ShowId)
            return BadRequest();
            
        var existingShow = _showService.GetShowById(showId);
        if(existingShow is null)
            return NotFound();
    
        _showService.UpdateShow(show);           
        return NoContent();
    }

    [HttpDelete("{showId}")]
    public IActionResult Delete(int showId) {
        var show = _showService.GetShowById(showId);
    
        if (show is null)
            return NotFound();
        
        _showService.DeleteShow(showId);
    
        return NoContent();
    }


    //GENRES
    [HttpGet("/Genre")]
    public ActionResult<List<string>> GetAllGenres() =>
        _showService.GetAllGenres();

    [HttpGet("/Genre/{nameGenre}")]
    public ActionResult<List<Show>> GetShowsByGenre(string nameGenre) {
        var shows = _showService.GetShowsByGenre(nameGenre);
        if (shows == null) {
            return NotFound();
        }
        return shows;
    }


    //SESSIONS
    // [HttpGet("{showId}/Session")]
    // public ActionResult<List<Session>> GetAllSessionsByShow(int showId) =>
    //     _showService.GetAllSessionsByShow(showId);

    // [HttpGet("{showId}/Session/{sessionId}")]
    // public ActionResult<Session> GetSession(int showId, int sessionId) {
    //     var session = _showService.GetSessionById(showId, sessionId);

    //     if(session == null)
    //         return NotFound();

    //     return session;
    // }

    // [HttpPost("{showId}/Session")]
    // public IActionResult CreateSession(int showId, Session session) {            
    //     _showService.AddSession(showId, session);
    //     return CreatedAtAction(nameof(GetSession), new { sessionId = session.SessionId }, session);
    // }

    // [HttpDelete("{showId}/Session/{sessionId}")]
    // public IActionResult DeleteSession(int showId, int sessionId) {
    //     var show = _showService.GetShowById(showId);
    
    //     if (show is null)
    //         return NotFound();
        
    //     _showService.DeleteSession(showId, sessionId);
    
    //     return NoContent();
    // }

    // [HttpPut("{showId}/Session/{sessionId}")]
    // public IActionResult UpdateSession(int showId, int sessionId, Session session) {
    //     if (sessionId != session.SessionId)
    //         return BadRequest();
            
    //     var existingSession = _showService.GetSessionById(showId, sessionId);
    //     if(existingSession is null)
    //         return NotFound();
    
    //     _showService.UpdateSession(showId, sessionId, session);           
    //     return NoContent();
    // }

}