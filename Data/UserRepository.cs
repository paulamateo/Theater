using System.Text;
using System.Text.Json;
using Theater.Models;

namespace Theater.Data {

    public class UserRepository : IUserRepository {
        private List<User> Users { get; }
        private int nextId = 1;

        public UserRepository() {
            Users = new List<User>();
        }

        public List<User> GetAllUsers() => Users;

        public User? GetUserById(int userId) => Users.FirstOrDefault(u => u.UserId == userId);

        public void AddUser(User user) {
            user.UserId = nextId++;
            Users.Add(user);
        }

        public void DeleteUser(int userId) {
            var user = GetUserById(userId);
            if (user is null)
                return;
            Users.Remove(user);
        }

        public void UpdateUser(User user) {
            var index = Users.FindIndex(u => u.UserId == user.UserId);
            if (index == -1)
                return;
            Users[index] = user;
        }
        
    }
}