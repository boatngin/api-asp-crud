using Microsoft.EntityFrameworkCore;
using Backapi.Data;
using Backapi.DTOs;
using Backapi.Models;
using Backapi.Repositories.Interfaces;

namespace Backapi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> AddUser(User user)
        {
            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return user;
        }

        
    }
}