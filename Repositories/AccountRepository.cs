using System.Threading.Tasks;
using sportlife.Data;
using sportlife.Models;

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

        public Task<Account> Update(Account model)
        {
            throw new System.NotImplementedException();
        }
    }
}