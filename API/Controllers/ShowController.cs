using Theater.Models;
using Theater.Business;
using Microsoft.AspNetCore.Mvc;

namespace Theater.Controllers;

[ApiController]
[Route("[controller]")]
public class ShowController : ControllerBase {
    private readonly IShowService _showService;
    private readonly ISessionService _sessionService;

    public ShowController (IShowService showService, ISessionService sessionService) {
        _showService = showService;
        _sessionService = sessionService;
    }

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

    //SEATS
    // [HttpGet("{showId}/Session/{sessionId}/Seat")]
    // public ActionResult<List<Seat>> GetAllSeats(int showId, int sessionId) {
    //     var seats = _sessionService.GetSeatsForSessionAndShow(showId, sessionId);
    //     return seats;
    // }

    // [HttpGet("{showId}/Session/{sessionId}/Seat/{seatId}")]
    // public ActionResult<Seat> GetSeat(int showId, int sessionId, int seatId) {
    //     var seat = _sessionService.GetSeat(sessionId, showId, seatId);

    //     if (seat == null) {
    //         return NotFound();
    //     }
    //     return seat;
    // }

    // [HttpPost("{showId}/Session/{sessionId}/Seat")]
    // public ActionResult CreateSeat(int sessionId, int showId, Seat seat) {
    //     _sessionService.AddSeat(sessionId, showId, seat);
    //     return CreatedAtAction(nameof(GetSeat), new { seatId = seat.SeatId }, seat);
    // }



    [HttpPost()]
    public IActionResult Create(ShowDTO show) {            
        _showService.AddShow(show);
        return CreatedAtAction(nameof(Get), new { showId = show.ShowId }, show);
    }

    [HttpPut("{showId}")]
    public IActionResult Update(int showId, ShowDTO show) {
        if (showId != show.ShowId)
            return BadRequest();
            
        var existingShow = _showService.GetShowById(showId);
        if(existingShow is null)
            return NotFound();
    
        _showService.UpdateShow(show);           
        return Ok();
    }

    [HttpDelete("{showId}")]
    public IActionResult Delete(int showId) {
        var show = _showService.GetShowById(showId);
    
        if (show is null)
            return NotFound();
        
        _showService.DeleteShow(showId);
    
        return NoContent();
    }


    //SESSIONS
    // [HttpGet("{showId}/Session")]
    // public ActionResult<List<Session>> GetSessionsByShowId(int showId) =>
    //     _sessionService.GetSessionsByShowId(showId);

    // [HttpGet("{showId}/Session/{sessionId}")]
    // public ActionResult<Session> GetSession(int showId, int sessionId) {
    //     var session = _sessionService.GetSessionById(showId, sessionId);

    //     if(session == null)
    //         return NotFound();

    //     return session;
    // }

    // [HttpPost("{showId}/Session")]
    // public IActionResult CreateSession(int showId, Session session) {            
    //     _sessionService.AddSession(showId, session);
    //     return CreatedAtAction(nameof(GetSession), new { sessionId = session.SessionId }, session);
    // }

    // [HttpDelete("{showId}/Session/{sessionId}")]
    // public IActionResult DeleteSession(int showId, int sessionId) {
    //     var show = _showService.GetShowById(showId);
    
    //     if (show is null)
    //         return NotFound();
        
    //     _sessionService.DeleteSession(showId, sessionId);
    
    //     return NoContent();
    // }

    // [HttpPut("{showId}/Session/{sessionId}")]
    // public IActionResult UpdateSession(int showId, int sessionId, Session session) {
    //     if (sessionId != session.SessionId)
    //         return BadRequest();
            
    //     var existingSession = _sessionService.GetSessionById(showId, sessionId);
    //     if(existingSession is null)
    //         return NotFound();
    
    //     _sessionService.UpdateSession(showId, sessionId, session);           
    //     return NoContent();
    // }

}