using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        User? ValidateUser(string email, string password);

        Task AddUser(User user);

        Task<User?> GetUserById(int id);

        Task<List<User>> GetAllUsers();

        Task UpdateUserAsync(User user);

        Task DeleteUser(int id);
    }
}