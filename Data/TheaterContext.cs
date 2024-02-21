using Microsoft.EntityFrameworkCore;
using Theater.Models;

namespace Theater.Data {

    public class TheaterContext : DbContext {
        public TheaterContext(DbContextOptions<TheaterContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { 
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, UserName = "Paula", UserLastname = "Mateo", Email = "a26619@svalero.com", Password = "1234", PhoneNumber = "123456789", IsAdmin = true}
            );
        }

        public DbSet<Show> Shows { get; set; }
        public DbSet<User> Users { get; set; }

    }
    
}