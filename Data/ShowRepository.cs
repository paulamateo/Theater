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
            show.QuantitySeats = 135;
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

        //metodo LISTAR TODOS LOS GENEROS
        // public List<string> GetAllGenres() {
        //     var shows = GetAllShows().ToList();
        //     foreach (var show in shows) {

        //     }
        // }




//             foreach (var show in shows) {
//                 if (!string.IsNullOrEmpty(show.Genre)) {
//                     allGenres.Add(show.Genre);
//                 }
//                 if (show.Genres != null && show.Genres.Count > 0) {
//                     allGenres.UnionWith(show.Genres);
//                 }
//             }

//             return new List<string>(allGenres);
//         }


        //metodo GET BY NAME
       

        //metodo LISTAR TODAS LAS OBRAS POR GÉNERO


        //SEATS
        //metodo LISTAR ASIENTOS BY OBRA
        // public List<Seat> GetSeatsByShow(int showId) {
        //     var show = GetShowById(showId);
        //     if (show is null) {
        //         throw new KeyNotFoundException("Show not found.");
        //     }
           
        // }

  
    

    }

}