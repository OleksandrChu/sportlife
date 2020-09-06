using System.Collections.Generic;
using System.Threading.Tasks;
using sportlife.Data;
using sportlife.Models;

namespace sportlife.Services
{
    public class HistoryService : IHistoryService
    {
        private readonly ApplicationDbContext _context;

        public HistoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceHistory> Create(ServiceHistory model)
        {
            await _context.ServiceHistories.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public Task<List<ServiceHistory>> SelectAll()
        {
            throw new System.NotImplementedException();
        }
    }
}