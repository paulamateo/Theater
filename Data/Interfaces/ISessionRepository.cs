using Theater.Models;

namespace Theater.Data {

    public interface ISessionRepository {
        List<Session> GetAllSessionsByShow(int showId);
        Session? GetSessionById(int showId, int sessionId);
        void AddSession(int showId, Session session);
        void DeleteSession(int showId, int sessionId);
        void UpdateSession(int showId, int sessionId, Session session);
        List<Session> GetAllSessions();
        List<Session> GetSessionsByShowId(int showId);
    }

}