using System.Text;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Theater.Models;

namespace Theater.Data {
    
    public class SessionRepository : ISessionRepository {
        private readonly TheaterContext _context;
        private readonly IShowRepository _showRepository;

        public SessionRepository(TheaterContext context, IShowRepository showRepository) {
            _context = context;
            _showRepository = showRepository;
        }

        public void SaveChanges() {
            _context.SaveChanges();
        }

        //SESSIONS
        public List<Session> GetAllSessions() {
            return _context.Sessions.ToList();
        }

        public Session? GetSessionById(int sessionId) {
            return _context.Sessions.FirstOrDefault(s => s.SessionId == sessionId);
        }
        
        public void AddSession(SessionCreateDTO session) {
            var show = _context.Shows.FirstOrDefault(s => s.ShowId == session.ShowId);
            if (show is null) {
                throw new KeyNotFoundException("Show not found.");
            }

            DateTime sessionDateTime = new DateTime(show.Date.Year, show.Date.Month, show.Date.Day, session.Hour.Hour, session.Hour.Minute, session.Hour.Second);
            
            var newSession = new Session {
                Hour = sessionDateTime,
                TotalSeats = session.TotalSeats,
                Notes = session.Notes,
                ShowId = session.ShowId,
                Title = show.Title,
                Poster = show.Poster
            };

            _context.Sessions.Add(newSession);
            SaveChanges();
        }

        // public List<Session> GetSessionsByShowId(int showId) {
        //     return _context.Sessions.Where(s => s.ShowId == showId).ToList();
        // }

        // public List<Session> GetAllSessionsByShow(int showId) {
        //     var show = _showRepository.GetShowById(showId);
        //     if (show is null) {
        //         throw new KeyNotFoundException("Show not found.");
        //     }
        //     return _context.Sessions.Where(s => s.ShowId == showId).ToList();
        // }

        // public Session? GetSessionById(int showId, int sessionId) {
        //     var show = _showRepository.GetShowById(showId);
        //     if (show is null) {
        //         throw new KeyNotFoundException("Show not found.");
        //     }
        //     return _context.Sessions.FirstOrDefault(s => s.ShowId == showId && s.SessionId == sessionId);
        // }

        // public void AddSession(int showId, Session session) {
        //     var show = _showRepository.GetShowById(showId);
        //     if (show is null) {
        //         throw new KeyNotFoundException("Show not found.");
        //     }
        //     _context.Sessions.Add(session);
        //     SaveChanges();
        // }

        // public void DeleteSession(int showId, int sessionId) {
        //     var session = GetSessionById(showId, sessionId);
        //     if (session is null) {
        //         throw new KeyNotFoundException("Session not found.");
        //     }
        //     _context.Sessions.Remove(session);
        //     SaveChanges(); 
        // }

        // public void UpdateSession(int showId, int sessionId, Session session) {
        //     var show = _showRepository.GetShowById(showId);
        //     if (show is null) {
        //         throw new KeyNotFoundException("Show not found.");
        //     }
        //     var existingSession = GetSessionById(showId, sessionId);
        //     _context.Entry(existingSession ?? throw new InvalidOperationException("This session is null")).State = EntityState.Modified;
        //    SaveChanges();
        // }


        //SEATS
        // public List<Seat> GetSeatsForSessionAndShow(int sessionId, int showId) {
        //     var session = GetSessionById(showId, sessionId);
        //     if (session is null) {
        //         throw new KeyNotFoundException("Session not found.");
        //     }
        //     var seats = _context.Seats.Where(s => s.ShowId == showId && s.SessionId == sessionId).ToList();
        //     return seats;
        // }

        // public Seat? GetSeat(int sessionId, int showId, int seatId) {
        //     var session = GetSessionById(showId, sessionId);
        //     if (session is null) {
        //         throw new KeyNotFoundException("Session not found.");
        //     }
        //     return _context.Seats.FirstOrDefault(s => s.SeatId == seatId && s.SessionId == sessionId && s.ShowId == showId);

        // }

        // public void AddSeat(int sessionId, int showId, Seat seat) {
        //     var session = GetSessionById(showId, sessionId);
        //     if (session is null) {
        //         throw new KeyNotFoundException("Session not found.");
        //     }
        //     _context.Seats.Add(seat);
        //     SaveChanges();
        // }

    }
}