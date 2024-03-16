using Theater.Models;

namespace Theater.Data {

    public interface ISessionRepository {
        List<Session> GetAllSessions();
        Session? GetSessionById(int sessionId);
        void AddSession(Session session);
        void DeleteSession(int sessionId);
        void UpdateSession(Session session);
        List<Seat> GetSeatsBySession(int sessionId);
        Seat? GetSeatById(int sessionId, int seatId);
        void AddSeat(int sessionId, Seat seat);
    }

}