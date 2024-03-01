using Microsoft.EntityFrameworkCore;
using Theater.Models;

namespace Theater.Data {

    public class TheaterContext : DbContext {
        public TheaterContext(DbContextOptions<TheaterContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { 
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reservations)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Session>()
                .HasMany(s => s.Reservations)
                .WithOne(r => r.Session)
                .HasForeignKey(r => r.SessionId);

            modelBuilder.Entity<Show>()
                .HasMany(s => s.Sessions)
                .WithOne(s => s.Show)
                .HasForeignKey(s => s.ShowId);  
            
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, UserName = "Paula", UserLastname = "Mateo", Email = "a26619@svalero.com", Password = "1234", PhoneNumber = "123456789", IsAdmin = true}
            );

            modelBuilder.Entity<Show>().HasData(
                new Show { 
                    ShowId = 1, 
                    Title = "El Fantasma de la Ópera", 
                    Author = "Gaston Leroux", 
                    Director = "Sara García", 
                    Genre = "Musical", 
                    Age = 18, 
                    Length = "2h 30min", 
                    Overview = "En la majestuosa Ópera Garnier de París, 'El Fantasma de la Ópera' despliega una intrigante trama donde la talentosa soprano Christine Daaé se encuentra en medio de un apasionante triángulo amoroso. Entre el enigmático Fantasma, un genio musical desfigurado que la guía desde las sombras, y el apasionado vizconde Raoul de Chagny, la historia explora los límites entre la belleza y la fealdad, la obsesión y la devoción, creando una atmósfera fascinante en el esplendor de la ópera parisina. La narrativa se teje con emociones intensas, llevando al espectador a las profundidades de la pasión humana, la tragedia y el misterio en un escenario donde la música y el amor convergen de manera inolvidable."
                },
                new Show { 
                    ShowId = 2, 
                    Title = "Macbeth", Author = "William Shakespeare", Director = "Carlos Montoya", Genre = "Tragedia", Age = 16, Length = "2h 40min" },
                new Show { ShowId = 3, Title = "Hamlet", Author = "William Shakespeare", Director = "Ana Sánchez", Genre = "Musical", Age = 14, Length = "2h 15min" },
                new Show { ShowId = 4, Title = "El Cascanueces", Author = "Andrew Lloyd Webber", Director = "Daniela Méndez", Genre = "Ballet", Age = 16, Length = "2h 30min" },
                new Show { ShowId = 5, Title = "Divina Comedia", Author = "Dante Alighieri", Director = "Luis Rosa", Genre = "Drama", Age = 18, Length = "2h 30min" },
                new Show { ShowId = 6, Title = "Edipo Rey", Author = "Sófocles", Director = "Rafael López", Genre = "Tragedia", Age = 16, Length = "2h 45min" },
                new Show { ShowId = 7, Title = "Romeo y Julieta", Author = "William Shakespeare", Director = "Marta Váldez", Genre = "Tragedia", Age = 16, Length = "2h 30min" }
            );

            

        }

        public DbSet<Show> Shows { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

    }
    
}