using System.ComponentModel.DataAnnotations;

namespace Theater.Models {
    public class SeatCreateDTO {
        [Key]
        public int SeatId { get; set; } 
        public int SeatIdReserved { get; set; }
        public bool IsDisponible { get; set; }
        public int SessionId { get; set; }
    }
}