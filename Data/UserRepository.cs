using Microsoft.EntityFrameworkCore;
using Theater.Models;

namespace Theater.Data {
    
    public class UserRepository : IUserRepository {
        private readonly TheaterContext _context;

        public UserRepository(TheaterContext context) {
            _context = context;
        }

        public void SaveChanges() {
            _context.SaveChanges();
        }

        public List<User> GetAllUsers() {
            return _context.Users.ToList();
        }

        public User? GetUserById(int userId) {
            return _context.Users.FirstOrDefault(u => u.UserId == userId);
        }

        public void AddUser(User user) {
            _context.Users.Add(user);
            SaveChanges();
        }

        public void DeleteUser(int userId) {
            var user = GetUserById(userId);
            if (user is null) {
                throw new KeyNotFoundException("User not found.");
            }
            _context.Users.Remove(user);
            SaveChanges();
        }

        public void UpdateUser(User user) {
            _context.Entry(user).State = EntityState.Modified;
            SaveChanges();
        } 

        public User? Login(string email, string password) {
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password && u.IsAdmin);

            if(user == null) {
                return null;
            }

            return user;
        }

    }
    
}