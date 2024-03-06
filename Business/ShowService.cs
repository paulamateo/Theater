using Theater.Models;
using Theater.Data;

namespace Theater.Business {
    
    public class ShowService : IShowService {
        private readonly IShowRepository _showRepository;

        public ShowService(IShowRepository showRepository) {
            _showRepository = showRepository;
        } 

        //SHOWS
        public List<Show> GetAllShows() => _showRepository.GetAllShows();
        public Show? GetShowById(int showId) => _showRepository.GetShowById(showId);
        public void AddShow(Show show) => _showRepository.AddShow(show);
        public void DeleteShow(int showId) => _showRepository.DeleteShow(showId);
        public void UpdateShow(Show show) => _showRepository.UpdateShow(show);

        //GENRES
        public List<string> GetAllGenres() => _showRepository.GetAllGenres();
        public List<Show> GetShowsByGenre(string genre) => _showRepository.GetShowsByGenre(genre);

        //SESSIONS
        public List<Session> GetAllSessionsByShow(int showId)  => _showRepository.GetAllSessionsByShow(showId);
        public Session? GetSessionById(int showId, int sessionId) => _showRepository.GetSessionById(showId, sessionId);
        public void AddSession(int showId, Session session) => _showRepository.AddSession(showId, session);
        public void DeleteSession(int showId, int sessionId) => _showRepository.DeleteSession(showId, sessionId);
        public void UpdateSession(int showId, int sessionId, Session session) => _showRepository.UpdateSession(showId, sessionId, session);


        public List<Session> GetAllSessions() => _showRepository.GetAllSessions();
        public List<Session> GetSessionsByShowId(int showId) => _showRepository.GetSessionsByShowId(showId);
    }

}