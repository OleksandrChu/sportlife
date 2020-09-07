using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sportlife.Builders;
using sportlife.Data;
using sportlife.Models;

namespace sportlife.Services
{
    public class MembershipService : IMembershipService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMembershipBuilder _builder;

        public MembershipService(ApplicationDbContext context, IMembershipBuilder builder)
        {
            _context = context;
            _builder = builder;
        }

        public async Task<MemberShip> Create(MemberShip model)
        {
            model.Account = _context.Accounts.Find(_context.Accounts.Max(p => p.Id));
            _context.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<MemberShip> Select(int id)
        {
            var memberShip = await _context.Memberships
                .Include(p => p.Account)
                .Where(y => y.Id == id).FirstAsync();
            memberShip.Account.Balance = _context.Transactions
                                                    .Where(t => t.AccountId == memberShip.Account.Id)
                                                    .Sum(transaction => transaction.Amount);
            _builder.IncludeServicesTo(memberShip);
            return memberShip;
        }
    }
}