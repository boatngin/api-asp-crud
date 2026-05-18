using Backapi.DTOs;
using Backapi.Models;

namespace Backapi.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> AddUser(User user);

        Task<object> GetUsersDatatable(UserDataReq request);

        // Task<User?> GetUserById(int id);

        // Task<User?> EditUser(int id, User user);

        // Task<bool> DeleteUser(int id);
        // Task GetUsersDatatable(User request);
    }
}