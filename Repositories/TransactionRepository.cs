using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sportlife.Data;
using sportlife.Models;

namespace sportlife.Repositories
{
    public class TransactionRepository : IRepository<Transaction>
    {
        private readonly ApplicationDbContext _context;
        public TransactionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Transaction> Create(Transaction model)
        {
            _context.Transactions.Add(model);
            var account = _context.Accounts
                            .Where(acc => acc.Id == model.AccountId)
                            .First();
            account.Balance += model.Amount;
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<List<Transaction>> SelectAll(int id)
        {
            return await _context.Transactions
                .Where(transaction => transaction.AccountId == id)
                .ToListAsync();
        }

        public Task<Transaction> Select(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Transaction> Update(Transaction model)
        {
            throw new System.NotImplementedException();
        }
    }
}