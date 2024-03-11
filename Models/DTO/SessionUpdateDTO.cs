namespace Theater.Models {
    public class SessionUpdateDTO {
        public int SessionId { get; set; }
        public string? Hour { get; set; } 
        public int TotalSeats { get; set; }
        public string? Notes { get; set; }
        
    }
}