using Microsoft.EntityFrameworkCore;
using Theater.Models;

namespace Theater.Data {
    
    public class UserRepository : IUserRepository {
        private readonly TheaterContext _context;
        private int nextId;

        public UserRepository(TheaterContext context) {
            _context = context;
        }

        //USER
        public List<User> GetAllUsers() {
            return _context.Users.ToList();
        }

        public User? GetUserById(int userId) {
            return _context.Users.FirstOrDefault(u => u.UserId == userId);
        }

        public void AddUser(User user) {
            user.UserId = nextId++;
            _context.Users.Add(user);
        }

        public void DeleteUser(int userId) {
            var user = GetUserById(userId);
            if (user is null) {
                throw new KeyNotFoundException("User not found.");
            }
            _context.Users.Remove(user);
        }

        public void UpdateUser(User user) {
            _context.Entry(user).State = EntityState.Modified;
        }

        //SESSIONS
        
        
    }
    
}