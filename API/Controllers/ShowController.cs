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

    [HttpGet()]
    public ActionResult<List<Show>> GetAll() =>  _showService.GetAllShows();

    [HttpGet("{showId}")]
    public ActionResult<Show> Get(int showId) {
        var show = _showService.GetShowById(showId);

        if(show == null)
            return NotFound();

        return show;
    }

    [HttpGet("ByName/{title}")]
    public ActionResult<Show> GetByTitle(string title) {
        var show = _showService.GetShowByTitle(title);

        if(show == null)
            return NotFound();

        return show;
    }

    [HttpGet("{showId}/Session")]
    public ActionResult<List<Session>> GetSessionsByShow(int showId) {
        var sessions = _showService.GetSessionsByShow(showId);

        if (sessions == null) 
            return NotFound();

        return sessions;
    }

    [HttpPost()]
    public IActionResult Create([FromBody] ShowDTO show) {   
        var newShow = new Show {
            Title = show.Title,
            Author = show.Author,
            Director = show.Director,
            Genre = show.Genre,
            Age = show.Age,
            Date = show.Date,
            Length = show.Length,
            Price = show.Price,
            Poster = show.Poster,
            Banner = show.Banner,
            Scene = show.Scene,
            Overview = show.Overview
        };         
        _showService.AddShow(newShow);
        return CreatedAtAction(nameof(Get), new { showId = show.ShowId }, show);
    }

    [HttpPut("{showId}")]
    public IActionResult Update(int showId, [FromBody] ShowDTO show) {
        if (showId != show.ShowId)
            return BadRequest();
            
        var existingShow = _showService.GetShowById(showId);
        if(existingShow is null)
            return NotFound();

        existingShow.Title = show.Title;
        existingShow.Author = show.Author;
        existingShow.Director = show.Director;
        existingShow.Genre = show.Genre;
        existingShow.Age = show.Age;
        existingShow.Date = show.Date;
        existingShow.Length = show.Length;
        existingShow.Price = show.Price;
        existingShow.Poster = show.Poster;
        existingShow.Banner = show.Banner;
        existingShow.Scene = show.Scene;
        existingShow.Overview = show.Overview;

        _showService.UpdateShow(existingShow);           
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

}