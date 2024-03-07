using System.ComponentModel.DataAnnotations;

namespace Theater.Models {
    public class Session {
        [Key]
        public int SessionId { get; set; }
        public TimeSpan Hour { get; set; } 
        [Required]
        public int TotalSeats { get; set; }
        public List<Seat>? Seats { get; set; }
        [Required]
        public int ShowId { get; set; }
    }
}