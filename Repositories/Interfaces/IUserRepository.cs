using Backapi.DTOs;
using Backapi.Models;

namespace Backapi.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> AddUser(User user);

        Task<object> GetUsersDatatable(UserDataReq request);

        // Task<User?> GetUserById(int id);

        // Task<User?> EditUser(int id, User user);

        // Task<bool> DeleteUser(int id);
    }
}