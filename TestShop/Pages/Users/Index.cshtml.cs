using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Shop.Core.Services.Users;
using Shop.Data.Context;
using Shop.Domain.Models.Users;

namespace TestShop.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly IUserService _userService;

        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }

        public IList<Shop.Domain.Models.Users.User> UsersModel { get;set; }

        public async Task OnGetAsync()
        {
            UsersModel = await _userService.GetAllUsers();
        }
    }
}
