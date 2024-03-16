using System.Text;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Theater.Models;

namespace Theater.Data {
    
    public class SessionRepository : ISessionRepository {
        private readonly TheaterContext _context;
        private readonly IShowRepository _showRepository;
        private int nextId = 0;

        public SessionRepository(TheaterContext context, IShowRepository showRepository) {
            _context = context;
            _showRepository = showRepository;
        }

        public void SaveChanges() {
            _context.SaveChanges();
        }

        public List<Session> GetAllSessions() {
            return _context.Sessions.Include(s => s.Seats).ToList();
        }

        public Session? GetSessionById(int sessionId) {
            return _context.Sessions.FirstOrDefault(s => s.SessionId == sessionId);
        }

        public void AddSession(Session session) {
            session.SessionId = nextId++;
            _context.Sessions.Add(session);
            SaveChanges();
        }

        public void DeleteSession(int sessionId) {
            var session = GetSessionById(sessionId);
            if (session is null) {
                throw new KeyNotFoundException("Session not found.");
            }
            _context.Sessions.Remove(session);
            SaveChanges(); 
        }

        public void UpdateSession(Session session) {
            _context.Entry(session).State = EntityState.Modified;
            SaveChanges();
        }

        public List<Seat> GetSeatsBySession(int sessionId) {
            return _context.Seats.Where(s => s.SessionId == sessionId).ToList();
        }
        
        public Seat? GetSeatById(int sessionId, int seatId) {
            var session = GetSessionById(sessionId);
            if (session is null) 
                throw new KeyNotFoundException("Session not found.");
            return _context.Seats.FirstOrDefault(s => s.SessionId == sessionId && s.SeatId == seatId);
        }
  
        public void AddSeat(int sessionId, Seat seat) {
            var session = GetSessionById(sessionId);
            if (session == null) {
                throw new KeyNotFoundException("Session not found.");
            }
            seat.SessionId = sessionId;
            _context.Seats.Add(seat); 
            SaveChanges();
        }

    }
}