using System.ComponentModel.DataAnnotations;

namespace Theater.Models {
    public class Session {
        [Key]
        public int SessionId { get; set; }
        public TimeSpan Hour { get; set; } 
        [Required]
        public int Seats { get; set; }
        public List<Seat>? ReservedSeating { get; set; }
        [Required]
        public int ShowId { get; set; }
        public List<Reservation>? Reservations { get; set; }
    }
}