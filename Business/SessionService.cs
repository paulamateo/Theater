using Theater.Models;
using Theater.Data;

namespace Theater.Business {
    
    public class SessionService : ISessionService {
        private readonly ISessionRepository _sessionRepository;

        public SessionService(ISessionRepository sessionRepository) {
            _sessionRepository = sessionRepository;
        } 

        //SESSIONS
        public List<Session> GetAllSessionsByShow(int showId)  => _sessionRepository.GetAllSessionsByShow(showId);
        public Session? GetSessionById(int showId, int sessionId) => _sessionRepository.GetSessionById(showId, sessionId);
        public void AddSession(int showId, Session session) => _sessionRepository.AddSession(showId, session);
        public void DeleteSession(int showId, int sessionId) => _sessionRepository.DeleteSession(showId, sessionId);
        public void UpdateSession(int showId, int sessionId, Session session) => _sessionRepository.UpdateSession(showId, sessionId, session);


        public List<Session> GetAllSessions() => _sessionRepository.GetAllSessions();
        public List<Session> GetSessionsByShowId(int showId) => _sessionRepository.GetSessionsByShowId(showId);

        //SEATS
        // public List<Seat> GetSeatsForSessionAndShow(int sessionId, int showId) => _sessionRepository.GetSeatsForSessionAndShow(sessionId, showId);
        // public void AddSeat(int sessionId, int showId, Seat seat) => _sessionRepository.AddSeat(sessionId, showId, seat);
        // public Seat? GetSeat(int sessionId, int showId, int seatId) => _sessionRepository.GetSeat(sessionId, showId, seatId);
    }
}