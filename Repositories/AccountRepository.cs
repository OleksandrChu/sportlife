using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sportlife.Data;
using sportlife.Models;
using sportlife.Services;

namespace  sportlife.Repositories
{
    public class AccountRepository : IRepository<Account>
    {
        private readonly ApplicationDbContext _context;
        public AccountRepository(ApplicationDbContext context)
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
            var acc = await _context.Accounts.Include(a => a.Transactions).FirstAsync();
            return acc;
        }

        public async Task<Account> Update(Account model)
        {
            await _context.SaveChangesAsync();
            return model;
        }
    }
}