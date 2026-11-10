using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly BipassDbContext _dbContext;

        public UserRepository(BipassDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddUser(User user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User?> GetUserById(int id)
        {
            return await _dbContext.Users.FindAsync(id);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public User? ValidateUser(string email, string password)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Email == email && u.PasswordHash == password);
        }

        public async Task UpdateUserAsync(User user) 
        {
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync(); 
        }

        public async Task DeleteUser(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user != null)
            {
                _dbContext.Users.Remove(user);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}