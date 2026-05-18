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

        public async Task<object> GetUsersDatatable(
            UserDataReq request
        )
        {
            var query = _context.Users.AsQueryable();

            // if have serach
            if (!string.IsNullOrEmpty(request.Search))
            {
                query = query.Where(x =>
                    x.Fname.Contains(request.Search) ||
                    x.Lname.Contains(request.Search) ||
                    x.Email.Contains(request.Search) ||
                    x.Username.Contains(request.Search)
                );
            }

            // on order swtich
            switch (request.OrderBy?.ToLower())
            {
                case "fname":
                    query = request.OrderDirection == "desc"
                        ? query.OrderByDescending(x => x.Fname)
                        : query.OrderBy(x => x.Fname);
                    break;

                case "lname":
                    query = request.OrderDirection == "desc"
                        ? query.OrderByDescending(x => x.Lname)
                        : query.OrderBy(x => x.Lname);
                    break;

                default:
                    query = query.OrderBy(x => x.Id);
                    break;
            }

            var total = await query.CountAsync();

            var users = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            return new
            {
                total,
                pageNumber = request.PageNumber,
                pageSize = request.PageSize,
                data = users
            };
        }

        public async Task<User?> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User?> EditUser(int id, User request)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return null;
            }

            user.Fname = request.Fname;
            user.Lname = request.Lname;
            user.Email = request.Email;
            user.Phone = request.Phone;
            user.RoleId = request.RoleId;
            user.Username = request.Username;
            user.Password = request.Password;

            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return false;
            }

            _context.Users.Remove(user);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}