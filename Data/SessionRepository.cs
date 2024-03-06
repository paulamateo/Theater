using System.Text;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Theater.Models;

namespace Theater.Data {
    
    public class SessionRepository : ISessionRepository {
        private readonly TheaterContext _context;
        private readonly IShowRepository _showRepository;
        private int nextId;

        public SessionRepository(TheaterContext context, IShowRepository showRepository) {
            _context = context;
            _showRepository = showRepository;
        }

        public void SaveChanges() {
            _context.SaveChanges();
        }

        public List<Session> GetAllSessions() {
            return _context.Sessions.ToList();
        }
        
        public List<Session> GetSessionsByShowId(int showId) {
            return _context.Sessions.Where(s => s.ShowId == showId).ToList();
        }

        public List<Session> GetAllSessionsByShow(int showId) {
            var show = _showRepository.GetShowById(showId);
            if (show is null) {
                throw new KeyNotFoundException("Show not found.");
            }
            return _context.Sessions.Where(s => s.ShowId == showId).ToList();
        }

        public Session? GetSessionById(int showId, int sessionId) {
            var show = _showRepository.GetShowById(showId);
            if (show is null) {
                throw new KeyNotFoundException("Show not found.");
            }
            return _context.Sessions.FirstOrDefault(s => s.ShowId == showId && s.SessionId == sessionId);
        }

        public void AddSession(int showId, Session session) {
            var show = _showRepository.GetShowById(showId);
            if (show is null) {
                throw new KeyNotFoundException("Show not found.");
            }
            _context.Sessions.Add(session);
            SaveChanges();
        }

        public void DeleteSession(int showId, int sessionId) {
            var session = GetSessionById(showId, sessionId);
            if (session is null) {
                throw new KeyNotFoundException("Session not found.");
            }
            _context.Sessions.Remove(session);
            SaveChanges(); 
        }

        public void UpdateSession(int showId, int sessionId, Session session) {
            var show = _showRepository.GetShowById(showId);
            if (show is null) {
                throw new KeyNotFoundException("Show not found.");
            }
            var existingSession = GetSessionById(showId, sessionId);
            _context.Entry(existingSession ?? throw new InvalidOperationException("This session is null")).State = EntityState.Modified;
           SaveChanges();
        }

    }
}