﻿namespace Theater.Models;

public class Show {
    public int ShowId { get; set; }
    public string? Title { get; set; }
    public string? Author { get; set; }
    public string? Director { get; set; }
    public string? Genre { get; set; }
    public decimal Price { get; set; }
    public int Age { get; set; }
    public string? Length { get; set; }
    public DateTime Date { get; set; }
    public string? Poster { get; set; }
    public string? Banner { get; set; }
    public string? Scene { get; set; }
    public int Seats = 135;
    // public List<Seat> ReservedSeats { get}
    public string? Overview { get; set; }
}