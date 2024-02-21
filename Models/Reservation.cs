using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Theater.Models {
    public class Reservation {
        public int ReservationId { get; set; }
        public List<Seat>? SeatsReserved { get; set; }
        public decimal TotalPrice { get; set; }

        //USER, SHOW??

    }
}