using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using sportlife.Data;
using sportlife.Models;

namespace sportlife.Services
{
    public class StatisticsService : IStaticticsService
    {
        private readonly ApplicationDbContext _context;

        public StatisticsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable GetPaidServicesStatistics() {
            return  _context.ServiceHistories
                                .GroupBy(type => type.ServiceId)
                                .Select(membership => new {MemberShipType = membership.Key, UsedCount= membership.Count()});
        }

        public IQueryable GetMemberhipByTypeStatictics()
        {
            return  _context.Memberships
                                .GroupBy(type => type.Type)
                                .Select(membership => new {Type = membership.Key, Count= membership.Count()});
        }
    }
}