using Shop.Domain.Models;
using Shop.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Services.Transactions
{
    public interface ITransactionService
    {
        Task<List<Transaction>> GetAllTransaction();
        Task<bool> AddTransaction(Transaction transaction);
        Task<bool> EditTransaction(Transaction transaction);
        Task<Transaction> GetUserLastTransaction(int userId);
        Task<List<Transaction>> GetTransactionReport(int userId);
        Task<Transaction> GetMaxBuyer();
        Task<Transaction> GetMaxBuyerInToDay();
    }
}
