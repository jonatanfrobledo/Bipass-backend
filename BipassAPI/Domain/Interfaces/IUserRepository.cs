using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        User? ValidateUser(string email, string password);

        Task AddUser(User user);

        Task<User?> GetUserById(int id);

        // Agregados para corregir el error:
        Task<List<User>> GetAllUsers();

        Task UpdateUser(User user);

        Task DeleteUser(int id);
    }
}