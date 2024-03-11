using System.Text;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Theater.Models;

namespace Theater.Data {
    
    public class ShowRepository : IShowRepository {
        private readonly TheaterContext _context;

        public ShowRepository(TheaterContext context) {
            _context = context;
        }

        public void SaveChanges() {
            _context.SaveChanges();
        }

        public List<Show> GetAllShows() {
            return _context.Shows.Include(s => s.Sessions).ToList();
        }

        public Show? GetShowById(int showId) {
            return _context.Shows.FirstOrDefault(s => s.ShowId == showId);
        }

        public Show? GetShowByTitle(string title) {
            return _context.Shows.FirstOrDefault(s => s.Title == title);
        }

        public void AddShow(Show show) {
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

        public List<Session> GetSessionsByShow(int showId) {
            return _context.Sessions.Where(s => s.ShowId == showId).ToList();
        }


        //GENRES
        public List<string> GetAllGenres() {
            return _context.Shows.Select(s => s.Genre).Distinct().ToList()!;
        }

        public List<Show> GetShowsByGenre(string genre) {
            return _context.Shows.Where(s => s.Genre == genre).ToList();
        }

    }

}