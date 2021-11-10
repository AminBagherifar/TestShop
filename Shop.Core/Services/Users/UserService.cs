using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shop.Data.Context;
using Shop.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Services.Users
{
    public class UserService : BaseService,IUserService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<UserService> _logger;
        public UserService(AppDbContext context, ILogger<UserService> logger) :base(context)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> AddUser(User user)
        {
            try
            {
                Insert(user);
                await Save();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return false;
            }
        }

        public async Task<bool> EditUser(User user)
        {
            try
            {
                Update(user);
                await Save();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return false;
            }
        }

        public async Task<bool> EmailIsExist(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserById(int userId)
        {
            return await GetById<User>(userId);
        }
    }
}
