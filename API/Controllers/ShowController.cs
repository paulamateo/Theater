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
    [HttpGet("Genre")]
    public ActionResult<List<string>> GetAllGenres() =>
        _showService.GetAllGenres();

    [HttpGet("Genre/{nameGenre}")]
    public ActionResult<List<Show>> GetShowsByGenre(string nameGenre) {
        var shows = _showService.GetShowsByGenre(nameGenre);
        if (shows == null) {
            return NotFound();
        }
        return shows;
    }


}