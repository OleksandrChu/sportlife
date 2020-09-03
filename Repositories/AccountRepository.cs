using System.Threading.Tasks;
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
            return await _context.Accounts.FindAsync(id);
        }

        public async Task<Account> Update(Account model)
        {
            await _context.SaveChangesAsync();
            return model;
        }

        public Account TopUp(Account account, int amount)
        {
            account.Points += amount;
            return Update(account).Result;
        }

        public Account Pay(Account account, int amount)
        {
            account.Points -= amount;
            return Update(account).Result;
        }
    }
}