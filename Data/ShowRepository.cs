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
            return _context.Shows.Include(s => s.Sessions).ToList();
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

    }

}