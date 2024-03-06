using Theater.Models;
using Theater.Business;
using Microsoft.AspNetCore.Mvc;

namespace Theater.Controllers;

[ApiController]
[Route("[controller]")]
public class GenreController : ControllerBase {
    private readonly IShowService _showService;

    public GenreController (IShowService showService) {
        _showService = showService;
    }

    [HttpGet()]
    public ActionResult<List<string>> GetAllGenres() =>
        _showService.GetAllGenres();

    [HttpGet("{nameGenre}")]
    public ActionResult<List<Show>> GetShowsByGenre(string nameGenre) {
        var shows = _showService.GetShowsByGenre(nameGenre);
        if (shows == null) {
            return NotFound();
        }
        return shows;
    }
}