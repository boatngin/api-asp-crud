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

    }
}