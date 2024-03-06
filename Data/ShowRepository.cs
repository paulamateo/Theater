using System.Text;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Theater.Models;

namespace Theater.Data {
    
    public class ShowRepository : IShowRepository {
        private readonly TheaterContext _context;
        private int nextId;

        public ShowRepository(TheaterContext context) {
            _context = context;
        }

        public void SaveChanges() {
            _context.SaveChanges();
        }

        //SHOWS
        public List<Show> GetAllShows() {
            return _context.Shows.ToList();
        }

        public Show? GetShowById(int showId) {
            return _context.Shows.FirstOrDefault(s => s.ShowId == showId);
        }

        public void AddShow(Show show) {
            show.ShowId = nextId++;
            _context.Shows.Add(show);
            SaveChanges();
        }

        public void DeleteShow(int showId) {
            var show = GetShowById(showId);
            if (show is null) {
                throw new KeyNotFoundException("Show not found.");
            }
            _context.Shows.Remove(show);
            SaveChanges(); 
        }

        public void UpdateShow(Show show) {
            _context.Entry(show).State = EntityState.Modified;
           SaveChanges();
        }


        //GENRES
        public List<string> GetAllGenres() {
            return _context.Shows.Select(s => s.Genre).Distinct().ToList()!;
        }

        public List<Show> GetShowsByGenre(string genre) {
            return _context.Shows.Where(s => s.Genre == genre).ToList();
        }


        //SESSIONS
        public List<Session> GetAllSessions() {
            return _context.Sessions.ToList();
        }
        
        public List<Session> GetSessionsByShowId(int showId) {
            return _context.Sessions.Where(s => s.ShowId == showId).ToList();
        }




        public List<Session> GetAllSessionsByShow(int showId) {
            var show = GetShowById(showId);
            if (show is null) {
                throw new KeyNotFoundException("Show not found.");
            }
            return _context.Sessions.Where(s => s.ShowId == showId).ToList();
        }

        public Session? GetSessionById(int showId, int sessionId) { //{showId}/session/1
            var show = GetShowById(showId);
            if (show is null) {
                throw new KeyNotFoundException("Show not found.");
            }
            return _context.Sessions.FirstOrDefault(s => s.ShowId == showId && s.SessionId == sessionId);
        }

        public void AddSession(int showId, Session session) { //{showId}/session
            var show = GetShowById(showId);
            if (show is null) {
                throw new KeyNotFoundException("Show not found.");
            }
            _context.Sessions.Add(session);
            SaveChanges();
        }

        public void DeleteSession(int showId, int sessionId) { //{showId}/session/1
            var session = GetSessionById(showId, sessionId);
            if (session is null) {
                throw new KeyNotFoundException("Session not found.");
            }
            _context.Sessions.Remove(session);
            SaveChanges(); 
        }

        public void UpdateSession(int showId, int sessionId, Session session) { //{showId}/session/1
            var show = GetShowById(showId);
            if (show is null) {
                throw new KeyNotFoundException("Show not found.");
            }
            var existingSession = GetSessionById(showId, sessionId);
            _context.Entry(existingSession ?? throw new InvalidOperationException("This session is null")).State = EntityState.Modified;
           SaveChanges();
        }

    }

}