using System.Threading.Tasks;
using sportlife.Builders;
using sportlife.Data;
using sportlife.Models;

namespace sportlife.Repositories
{
    public class MembershipRepository : IRepository<MemberShip>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMembershipBuilder _builder;

        public MembershipRepository(ApplicationDbContext context, IMembershipBuilder builder)
        {
            _context = context;
            _builder = builder;
        }

        public async Task<MemberShip> Create(MemberShip model)
        {
            _context.Memberships.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<MemberShip> Select(int id)
        {
            var memberShip = await _context.Memberships.FindAsync(id);
            _builder.Build(memberShip);
            return memberShip;
        }

        public Task<MemberShip> Update(MemberShip model)
        {
            throw new System.NotImplementedException();
        }
    }
}