namespace Theater.Models {
    public class SessionCreateDTO {
        public int SessionId { get; set; }
        public string? Hour { get; set; } 
        public int TotalSeats { get; set; }
        public string? Notes { get; set; }
        public int ShowId { get; set; }
        
    }
}