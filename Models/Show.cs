using System.ComponentModel.DataAnnotations;

namespace Theater.Models {
    public class Show {
        [Key]
        public int ShowId { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Director { get; set; }
        public string? Genre { get; set; }
        public decimal Price { get; set; }
        public int Age { get; set; }
        public DateTime Date { get; set; }
        public string? Length { get; set; }
        public string? Poster { get; set; }
        public string? Banner { get; set; }
        public string? Scene { get; set; }
        public string? Overview { get; set; }
        public int QuantitySeats { get; set; }
        public List<Seat>? Seats { get; set; }

        // public Show() {
        //     Genres = new List<string>();
        // }

        // public List<string> Genres { get; set; }
    }
}