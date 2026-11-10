using Application.Models;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task AddUserAsync(User newUser)
        {
            await _userRepository.AddUser(newUser);
        }

        public async Task<UserDto?> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user == null) return null;

            return MapToDto(user);
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsers();
            return users.Select(MapToDto).ToList();
        }

        public async Task UpdateUserAsync(User updatedUser)
        {
            var userToUpdate = await _userRepository.GetUserById(updatedUser.Id);

            if (userToUpdate != null)
            {
                userToUpdate.FirstName = updatedUser.FirstName;
                userToUpdate.LastName = updatedUser.LastName;
                userToUpdate.PhoneNumber = updatedUser.PhoneNumber;
                userToUpdate.Role = updatedUser.Role;

                await _userRepository.UpdateUserAsync(userToUpdate);
            }
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteUser(id);
        }

        private static UserDto MapToDto(User user) => new UserDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            Role = user.Role
        };
    }
}