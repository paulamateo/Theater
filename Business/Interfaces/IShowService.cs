using Theater.Models;

namespace Theater.Business { 
    public interface IShowService {
        //SHOWS
        List<Show> GetAllShows();
        Show? GetShowById(int showId);
        void AddShow(Show show);
        void DeleteShow(int showId);
        void UpdateShow(Show show);

        //GENRES
        List<string> GetAllGenres();
        List<Show> GetShowsByGenre(string genre);
    }
}