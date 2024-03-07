using Theater.Models;

namespace Theater.Business { 
    public interface IShowService {
        //SHOWS
        List<Show> GetAllShows();
        Show? GetShowById(int showId);
        void AddShow(ShowDTO show);
        void DeleteShow(int showId);
        void UpdateShow(ShowDTO show);

        //GENRES
        List<string> GetAllGenres();
        List<Show> GetShowsByGenre(string genre);
    }
}