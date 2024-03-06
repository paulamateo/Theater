using Theater.Models;

namespace Theater.Data {

    public interface IShowRepository {
        //SHOWS
        List<Show> GetAllShows();
        Show? GetShowById(int showId);
        void AddShow(Show show);
        void DeleteShow(int showId);
        void UpdateShow(Show show);

        //GENRES
        List<string> GetAllGenres();
        List<Show> GetShowsByGenre(string genre);

        //SESSIONS
        List<Session> GetAllSessionsByShow(int showId);
        Session? GetSessionById(int showId, int sessionId);
        void AddSession(int showId, Session session);
        void DeleteSession(int showId, int sessionId);
        void UpdateSession(int showId, int sessionId, Session session);

        List<Session> GetAllSessions();
        List<Session> GetSessionsByShowId(int showId);
    }

}