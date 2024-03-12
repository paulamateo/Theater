using Theater.Models;

namespace Theater.Business { 
    public interface ISessionService {
        //SESSIONS
        List<Session> GetAllSessions();
        void AddSession(Session session);
        Session? GetSessionById(int sessionId);
        void DeleteSession(int sessionId);
        void UpdateSession(Session session);

        //SEATS
        List<Seat> GetSeatsBySession(int sessionId);
        Seat? GetSeatById(int sessionId, int seatId);
        void AddSeat(int sessionId, Seat seat);
    }
}