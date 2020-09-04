using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sportlife.Data;
using sportlife.Models;

namespace sportlife.Services
{
    public class ClientService : IClientService
    {
        private readonly ApplicationDbContext _context;
        
        public ClientService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Client> Create(Client client)
        {
            client.MemberShip = _context.Memberships.Find(_context.Memberships.Max(p => p.Id));
            _context.Add(client);
            await _context.SaveChangesAsync();
            return client;
        }

        public async Task<Client> Select(int id)
        {
            var client = await _context.Clients
                .Include(membership => membership.MemberShip)
                .Where(clientId => clientId.Id == id).FirstAsync();
            return client;
        }
    }
}