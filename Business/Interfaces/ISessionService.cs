using Theater.Models;

namespace Theater.Business { 
    public interface ISessionService {
        //SESSIONS
        // List<Session> GetAllSessionsByShow(int showId);
        // Session? GetSessionById(int showId, int sessionId);
        // void AddSession(int showId, Session session);
        // void DeleteSession(int showId, int sessionId);
        // void UpdateSession(int showId, int sessionId, Session session);

        List<Session> GetAllSessions();
        // List<Session> GetSessionsByShowId(int showId);

        //SEATS
        // List<Seat> GetSeatsForSessionAndShow(int sessionId, int showId);
        // void AddSeat(int sessionId, int showId, Seat seat);
        // Seat? GetSeat(int sessionId, int showId, int seatId);

        void AddSession(SessionCreateDTO session);
        Session? GetSessionById(int sessionId);
    }
}