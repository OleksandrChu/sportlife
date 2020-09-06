using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sportlife.Data;
using sportlife.Models;

namespace sportlife.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ApplicationDbContext _context;
        public TransactionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Transaction> Create(Transaction model)
        {
            _context.Transactions.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<List<Transaction>> SelectAll(int id)
        {
            return await _context.Transactions
                .Where(transaction => transaction.AccountId == id)
                .ToListAsync();
        }
    }
}