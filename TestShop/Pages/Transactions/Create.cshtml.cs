using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shop.Core.Services.Transactions;
using Shop.Core.Services.Users;
using Shop.Data.Context;
using Shop.Domain.Models;

namespace TestShop.Pages.Transactions
{
    public class CreateModel : PageModel
    {
        private readonly ITransactionService _transactionService;
        private readonly IUserService _userService;

        public CreateModel(ITransactionService transactionService, IUserService userService)
        {
            _transactionService = transactionService;
            _userService = userService;
        }

        [BindProperty]
        public Transaction TransactionModel { get; set; }

        public async Task<IActionResult> OnGet()
        {
            ViewData["UserId"] = new SelectList(await _userService.GetAllUsers(), "Id", "Email");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var transaction = await _transactionService.GetUserLastTransaction(TransactionModel.UserId);

            if (transaction != null)
            {
                transaction.EndDate = DateTime.Now.Date;
                transaction.IsFinaly = true;
                await _transactionService.EditTransaction(transaction);
            }

            TransactionModel.Total = TransactionModel.Sum + (transaction == null ? 0 : transaction.Total);
            TransactionModel.SatrtDate = DateTime.Now.Date;
            await _transactionService.AddTransaction(TransactionModel);

            return RedirectToPage("Index");
        }
    }
}
