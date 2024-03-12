using Theater.Models;

namespace Theater.Data {

    public interface IUserRepository {
        List<User> GetAllUsers();
        User? GetUserById(int userId);
        void AddUser(User user);
        void DeleteUser(int userId);
        void UpdateUser(User user);
        User? Login(string email, string password);
    }

}