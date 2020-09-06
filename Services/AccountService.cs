using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sportlife.Data;
using sportlife.Models;
using sportlife.Services;

namespace sportlife.Services
{
    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext _context;
        public AccountService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Account> Create(Account model)
        {
            _context.Accounts.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<Account> Select(int id)
        {
            var account = await _context.Accounts.Include(a => a.Transactions).FirstAsync();
            account.Balance = _context.Transactions
                        .Where(transaction => transaction.AccountId == account.Id)
                        .Sum(transaction => transaction.Amount);
            return account;
        }
    }
}