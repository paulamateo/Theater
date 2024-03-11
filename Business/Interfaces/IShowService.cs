using Theater.Models;

namespace Theater.Business { 
    public interface IShowService {
        List<Show> GetAllShows();
        Show? GetShowById(int showId);
        Show? GetShowByTitle(string title);
        void AddShow(Show show);
        void DeleteShow(int showId);
        void UpdateShow(Show show);
        List<string> GetAllGenres();
        List<Show> GetShowsByGenre(string genre);
        List<Session> GetSessionsByShow(int showId);
    }
}