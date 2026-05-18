using Backapi.DTOs;
using Backapi.Models;
using Backapi.Repositories.Interfaces;
using Backapi.Services.Interfaces;

namespace Backapi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<User> AddUser(User user)
        {
            return await _repository.AddUser(user);
        }

        public async Task<object> GetUsersDatatable(
            UserDataReq request
        )
        {
            return await _repository.GetUsersDatatable(request);
        }

        // public async Task<User?> GetUserById(int id)
        // {
        //     return await _repository
        // }

        // public async Task<User?> EditUser(int id, User user)
        // {
        //     return await _repository.
        // }

        // public async Task<bool> DeleteUser(int id)
        // {
        //     return await _repository.
        // }

    }
}