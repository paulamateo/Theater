using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Theater.Models {
    public class Reservation {
        [Key]
        public int ReservationId { get; set; }
        public List<Seat>? SeatsReserved { get; set; }
        public int TotalPrice { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public int SessionId { get; set; }
        public Session? Session { get; set; }
    }
}