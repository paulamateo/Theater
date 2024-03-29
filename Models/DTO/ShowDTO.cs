namespace Theater.Models {
    public class ShowDTO {
        public int ShowId { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Director { get; set; }
        public string? Genre { get; set; }
        public int Age { get; set; }
        public DateTime Date { get; set; }
        public string? Length { get; set; }
        public decimal Price { get; set; }
        public string? Poster { get; set; }
        public string? Banner { get; set; }
        public string? Scene { get; set; }
        public string? Overview { get; set; }
    }
}