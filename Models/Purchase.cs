using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Theater.Models {
    public class Purchase {
        [Key]
        public int PurchaseId { get; set; } 
        public DateTime DatePurchase { get; set; }
        public string? BuyerName { get; set; }
        public string? BuyerPhone { get; set; }
        public string? BuyerEmail { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalPrice { get; set; }
        public string? Title { get; set; }
        public int SessionId { get; set; }
        public List<Seat>? ReservedSeats { get; set; } = new List<Seat>();
    }
}