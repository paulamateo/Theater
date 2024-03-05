using Theater.Models;

namespace Theater.Data {

    public interface IShowRepository {
        List<Show> GetAllShows();
        Show? GetShowById(int showId);
        void AddShow(Show show);
        void DeleteShow(int showId);
        void UpdateShow(Show show);
        List<string> GetAllGenres();
        List<Show> GetShowsByGenre(string genre);
    }

}