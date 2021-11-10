using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shop.Core.Services.Users;
using Shop.Data.Context;
using Shop.Domain.Models.Users;

namespace TestShop.Pages.Users
{
    public class EditModel : PageModel
    {
        private readonly IUserService _userService;

        public EditModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public Shop.Domain.Models.Users.User UserModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int userId)
        {
            UserModel = await _userService.GetUserById(userId);

            if (User == null)
                return NotFound();

            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int userId)
        {
            if (!ModelState.IsValid)
                return Page();

            if (await _userService.EmailIsExist(UserModel.Email))
            {
                ModelState.AddModelError("UserModel.Email", "ایمیل وارد شده تکراری است");
                return Page();
            }

            UserModel.Id = userId;
            await _userService.EditUser(UserModel);

            return RedirectToPage("Index");
        }
    }
}
