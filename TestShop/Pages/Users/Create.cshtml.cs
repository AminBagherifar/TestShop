using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shop.Core.Services.Users;
using Shop.Data.Context;
using Shop.Domain.Models.Users;

namespace TestShop.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly IUserService _userService;

        public CreateModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public Shop.Domain.Models.Users.User UserModel { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            if (await _userService.EmailIsExist(UserModel.Email))
            {
                ModelState.AddModelError("UserModel.Email", "ایمیل وارد شده تکراری است");
                return Page();
            }

            await _userService.AddUser(UserModel);

            return RedirectToPage("Index");
        }
    }
}
