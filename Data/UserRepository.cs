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

        // public void UpdateUser(User user) {
        //     var userToBeUpdated = GetUserById(user.UserId);

        //     if (userToBeUpdated != null) {
        //         userToBeUpdated.UserName = user.UserName;
        //         userToBeUpdated.UserLastname = user.UserLastname;
        //         userToBeUpdated.Email = user.Email;

        //     }

            
        //     if (userUpdated is null)
        // {
        //     throw new KeyNotFoundException("No se encontro la obra a actualizar.");
        // }
        //     _context.Entry(userUpdated).CurrentValues.SetValues(user);
        //     SaveChanges();
        // }

        public void UpdateUser(User user) {
            _context.Entry(user).State = EntityState.Modified;
            SaveChanges();
        } 

//         public void UpdateUser(User user)
// {
//     var existingUser = GetUserById(user.UserId); // Buscamos el usuario existente en la base de datos

//     if (existingUser != null)
//     {
//         _context.Entry(existingUser).CurrentValues.SetValues(user); // Actualizamos las propiedades del usuario existente con los valores del usuario pasado como parámetro
//         _context.SaveChanges(); // Guardamos los cambios en la base de datos
//     }
// }


        
    }
    
}