using Shop.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Services.Users
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task<bool> AddUser(User user);
        Task<bool> EditUser(User user);
        Task<User> GetUserById(int userId);
        Task<bool> EmailIsExist(string email);
    }
}
