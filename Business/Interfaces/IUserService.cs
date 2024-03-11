using Theater.Models;

namespace Theater.Business {
    public interface IUserService {
        List<User> GetAllUsers();
        User? GetUserById(int userId);
        void AddUser(User user);
        void DeleteUser(int userId);
        void UpdateUser(User user);
        bool AuthenticateAdmin(string email, string password);
    }
}