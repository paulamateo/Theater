using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Theater.Models {
    public class SessionCreateDTO {
        public int SessionId { get; set; }
        public DateTime Hour { get; set; } 
        public int TotalSeats { get; set; }
        public string? Notes { get; set; }
        public int ShowId { get; set; }
        
    }
}