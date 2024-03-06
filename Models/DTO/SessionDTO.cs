using System.ComponentModel.DataAnnotations;

namespace Theater.Models {
    public class SessionDTO {
        public int SessionId { get; set; }
        public TimeSpan Hour { get; set; } 
        public int Seats { get; set; }
        public List<int>? ReservedSeating { get; set; }
        public int ShowId { get; set; }
    }
}