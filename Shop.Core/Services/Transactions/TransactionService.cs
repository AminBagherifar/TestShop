using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shop.Data.Context;
using Shop.Domain.Models;
using Shop.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Services.Transactions
{
    public class TransactionService: BaseService,ITransactionService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<TransactionService> _logger;
        public TransactionService(AppDbContext context, ILogger<TransactionService> logger) : base(context)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> AddTransaction(Transaction transaction)
        {
            try
            {
                Insert(transaction);
                await Save();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return false;
            }
        }

        public async Task<bool> EditTransaction(Transaction transaction)
        {
            try
            {
                Update(transaction);
                await Save();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return false;
            }
        }

        public async Task<List<Transaction>> GetAllTransaction()
        {
            return await _context.Transactions.ToListAsync();
        }

        public async Task<Transaction> GetMaxBuyer()
        {
            var query = _context.Transactions.Include(t=>t.User).AsQueryable();
            var maxValue = query.Max(x => x.Total);
            return await query.Where(x => x.Total == maxValue).FirstOrDefaultAsync();
        }

        public async Task<Transaction> GetMaxBuyerInToDay()
        {
            var query = _context.Transactions.Include(t => t.User).AsQueryable();
            var maxValue = query.Max(t => t.Total);
            return await query.Where(t => t.Total == maxValue && t.SatrtDate.Date == DateTime.Now.Date).FirstOrDefaultAsync();
        }

        public async Task<List<Transaction>> GetTransactionReport(int userId)
        {
            return await _context.Transactions.Where(t => t.UserId == userId).ToListAsync();
        }

        public async Task<Transaction> GetUserLastTransaction(int userId)
        {
            return await _context.Transactions.FirstOrDefaultAsync(t=>t.UserId==userId && !t.IsFinaly);
        }
    }
}
