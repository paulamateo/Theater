using Theater.Models;
using Theater.Business;
using Microsoft.AspNetCore.Mvc;

namespace Theater.Controllers;

[ApiController]
[Route("[controller]")]
public class SessionController : ControllerBase {
    private readonly ISessionService _sessionService;
    private readonly IShowService _showService;

    public SessionController (ISessionService sessionService, IShowService showService) {
        _sessionService = sessionService;
        _showService = showService;
    }

    //SESSIONS
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
    public IActionResult CreateSession([FromBody] SessionCreateDTO session) {    
        var show = _showService.GetAllShows().FirstOrDefault(s => s.ShowId == session.ShowId);

        if (show is null) {
            throw new KeyNotFoundException("Show not found.");
        } 

        var newSession = new Session {
            Hour = session.Hour, 
            TotalSeats = session.TotalSeats,
            Notes = session.Notes,
            ShowId = session.ShowId,
            Title = show.Title,
            Poster = show.Poster,
            Date = show.Date
        };

        _sessionService.AddSession(newSession);
        return CreatedAtAction(nameof(GetSession), new { sessionId = session.SessionId }, session);
    }

    [HttpDelete("{sessionId}")]
    public IActionResult DeleteSession(int sessionId) {
        var session = _sessionService.GetSessionById(sessionId);
    
        if (session is null)
            return NotFound();
        
        _sessionService.DeleteSession(sessionId);
    
        return NoContent();
    }

    [HttpPut("{sessionId}")]
    public IActionResult UpdateSession(int sessionId, [FromBody] SessionUpdateDTO session) {
        if (sessionId != session.SessionId)
            return BadRequest();
            
        var existingSession = _sessionService.GetSessionById(sessionId);
        if(existingSession is null)
            return NotFound();

        existingSession.Hour = session.Hour;
        existingSession.TotalSeats = session.TotalSeats;
        existingSession.Notes = session.Notes;

        _sessionService.UpdateSession(existingSession);           
        return NoContent();
    }

    //SEATS
    [HttpGet("{sessionId}/Seats")]
    public ActionResult<List<Seat>> GetAllSeats(int sessionId) {
        var session = _sessionService.GetSessionById(sessionId);

        if(session == null)
            return NotFound();

        var seats = _sessionService.GetSeatsBySession(sessionId);
        return seats;
    }

    [HttpGet("{sessionId}/Seats/{seatId}")]
    public ActionResult<Seat> GetSeat(int sessionId, int seatId) {
        var seat = _sessionService.GetSeatById(sessionId, seatId);

        if(seat == null)
            return NotFound();

        return seat;
    }

    [HttpPost("{sessionId}/Seats")]
     public IActionResult CreateSeat(int sessionId, [FromBody] SeatCreateDTO seat) {    
        var session = _sessionService.GetSessionById(sessionId);

        if (session is null) {
            throw new KeyNotFoundException("Session not found.");
        } 

        var newSeat = new Seat {
            SeatIdReserved = seat.SeatIdReserved,
            IsDisponible = seat.IsDisponible,
            SessionId = seat.SessionId
        };
      
        _sessionService.AddSeat(sessionId, newSeat);
        return CreatedAtAction(nameof(GetSeat), new { sessionId = sessionId, seatId = seat.SeatId }, seat);
    }


    //  [HttpPost("{sessionId}/Seats")]
    //  public IActionResult CreateSeat(int sessionId, [FromBody] Seat seat) {    
    //     var session = _sessionService.GetSessionById(sessionId);

    //     if (session is null) {
    //         throw new KeyNotFoundException("Session not found.");
    //     } 
      
    //     _sessionService.AddSeat(sessionId, seat);
    //     return CreatedAtAction(nameof(GetSeat), new { sessionId = sessionId, seatId = seat.SeatId }, seat);
    // }

}