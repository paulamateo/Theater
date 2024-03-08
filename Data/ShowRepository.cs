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

        //SHOWS
        public List<Show> GetAllShows() {
            return _context.Shows.Include(s => s.Sessions).ToList();
        }

        public Show? GetShowById(int showId) {
            return _context.Shows.FirstOrDefault(s => s.ShowId == showId);
        }

        public void AddShow(ShowDTO show) {
            var newShow = new Show {
                Title = show.Title,
                Author = show.Author,
                Director = show.Director,
                Genre = show.Genre,
                Age = show.Age,
                Date = show.Date,
                Length = show.Length,
                Price = show.Price,
                Poster = show.Poster,
                Banner = show.Banner,
                Scene = show.Scene,
                Overview = show.Overview
            };
            _context.Shows.Add(newShow);
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

        public void UpdateShow(ShowDTO show) {
            var showToBeUpdated = _context.Shows.FirstOrDefault(s => s.ShowId == show.ShowId);

            if (showToBeUpdated != null) {
                showToBeUpdated.Title = show.Title;
                showToBeUpdated.Author = show.Author;
                showToBeUpdated.Director = show.Director;
                showToBeUpdated.Genre = show.Genre;
                showToBeUpdated.Age = show.Age;
                showToBeUpdated.Date = show.Date;
                showToBeUpdated.Length = show.Length;
                showToBeUpdated.Price = show.Price;
                showToBeUpdated.Poster = show.Poster;
                showToBeUpdated.Banner = show.Banner;
                showToBeUpdated.Scene = show.Scene;
                showToBeUpdated.Overview = show.Overview;
                _context.SaveChanges();
            }
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