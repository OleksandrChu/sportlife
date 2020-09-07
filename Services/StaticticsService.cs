using System;
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

        public IQueryable GetUsingServicesStatistics()
        {
            return _context.ServiceHistories
                                .GroupBy(type => type.ServiceId)
                                .Select(service => new { ServiceId = service.Key, UsedCount = service.Count() });
        }

        public IQueryable GetMemberhipByTypeStatictics()
        {
            return _context.Memberships
                                .GroupBy(type => type.Type)
                                .Select(membership => new { Type = membership.Key, Count = membership.Count() });
        }

        public IQueryable GetVisitClubStatistics()
        {
            return _context.VisitHistories
                                .GroupBy(date => date.visitTime.Hour)
                                .Select(visit => new { Hour = visit.Key, Count = visit.Count() });
        }
    }
}