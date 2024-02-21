using System.ComponentModel.DataAnnotations;

namespace Theater.Models {
    public class Seat {
        [Key]
        public int SeatId { get; set; }
        public bool IsDisponible { get; set; }
    }
}