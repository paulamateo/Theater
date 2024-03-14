using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Theater.Models {
    public class PurchaseCreateDTO {
        public int PurchaseId { get; set; } 
        public DateTime DatePurchase { get; set; }
        public string? BuyerName { get; set; }
        public string? BuyerPhone { get; set; }
        public string? BuyerEmail { get; set; }
        public decimal TotalPrice { get; set; }
        public string? Title { get; set; }
        public int SessionId { get; set; }
    }
}