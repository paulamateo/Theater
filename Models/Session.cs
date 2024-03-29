using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Theater.Models {
    public class Session {
        [Key]
        public int SessionId { get; set; }
        public string? Hour { get; set; }
        [Required]
        public int TotalSeats { get; set; }
        public List<Seat> Seats { get; set; } = new List<Seat>();
        public string? Notes { get; set; }
        [Required]
        public int ShowId { get; set; }
        public string? Title { get; set; }
        public string? Poster { get; set; }
        public DateTime Date { get; set; }
    }

}