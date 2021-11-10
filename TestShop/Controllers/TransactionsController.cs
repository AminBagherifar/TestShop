using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Core.Services.Transactions;
using Shop.Core.Services.Users;
using Shop.Data.Context;
using Shop.Domain.Models;
using Shop.Domain.Models.Users;

namespace TestShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly IUserService _userService;

        public TransactionsController(ITransactionService transactionService, IUserService userService)
        {
            _transactionService = transactionService;
            _userService = userService;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<List<Transaction>>> GetTransactionReport(int userId)
        {
            var transaction = await _transactionService.GetTransactionReport(userId);

            if (transaction==null)
                return NotFound();

            return transaction;
        }

        [HttpGet]
        public async Task<ActionResult<User>> GetMaxBuyer()
        {
            var transaction = await _transactionService.GetMaxBuyer();
            if (transaction == null)
                return NotFound();
            var user = await _userService.GetUserById(transaction.UserId);

            return user;
        }

        [HttpGet]
        public async Task<ActionResult<User>> GetMaxBuyerInDate()
        {
            var transaction = await _transactionService.GetMaxBuyerInToDay();
            if (transaction==null)
                return NotFound();
            var user = await _userService.GetUserById(transaction.UserId);

            return Content($"Name : {user.Name} , Family : {user.Family} , startDate : {transaction.SatrtDate} , endDate : {transaction.EndDate} , Email : {user.Email}", "application/json");
        }
    }
}
