using System.ComponentModel.DataAnnotations;

namespace Theater.Models {
    public class Session {
        [Key]
        public int SessionId { get; set; }
        [Required]
        public DateTime DateSession { get; set; }
        [Required]
        public int QuantitySeats { get; set; }
        [Required]
        public List<Seat>? Seats { get; set; }
        public int ShowId { get; set; }
        public Show? Show { get; set; } 
        public List<Reservation>? Reservations { get; set; }
    }
}