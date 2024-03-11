using Theater.Models;
using Theater.Data;

namespace Theater.Business {
    
    public class SessionService : ISessionService {
        private readonly ISessionRepository _sessionRepository;

        public SessionService(ISessionRepository sessionRepository) {
            _sessionRepository = sessionRepository;
        } 

        //SESSIONS
        public List<Session> GetAllSessions() => _sessionRepository.GetAllSessions();
        public void AddSession(Session session) => _sessionRepository.AddSession(session);
        public Session? GetSessionById(int sessionId) => _sessionRepository.GetSessionById(sessionId);
        public void DeleteSession(int sessionId) => _sessionRepository.DeleteSession(sessionId);
        public void UpdateSession(Session session) => _sessionRepository.UpdateSession(session);

        //SEATS
        public List<Seat> GetSeatsBySession(int sessionId) => _sessionRepository.GetSeatsBySession(sessionId);
        public void AddSeat(int sessionId, Seat seat) => _sessionRepository.AddSeat(sessionId, seat);
        public Seat? GetSeatById(int sessionId, int seatId) => _sessionRepository.GetSeatById(sessionId, seatId);
    }
}