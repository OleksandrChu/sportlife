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

        public IQueryable GetUsingServicesStatistics() {
            return  _context.ServiceHistories
                                .GroupBy(type => type.ServiceId)
                                .Select(service => new {ServiceId = service.Key, UsedCount= service.Count()});
        }

        public IQueryable GetMemberhipByTypeStatictics()
        {
            return  _context.Memberships
                                .GroupBy(type => type.Type)
                                .Select(membership => new {Type = membership.Key, Count= membership.Count()});
        }

        public Dictionary<int, List<VisitHistory>> GetVisitClubStatistics()
        {
            var startDate = new DateTime(2020, 1, 1, 9, 0, 0);
            var endDate = new DateTime(2020, 1, 1, 23, 0, 0);
            Dictionary<int, List<VisitHistory>> list = new Dictionary<int, List<VisitHistory>>();
            for (var time = startDate; time < endDate; time = time.AddHours(1))
            {
                list[time.Hour] =  _context.VisitHistories.Where(storedTime => storedTime.visitTime.Hour.Equals(time.Hour)).ToList();
            }
            return  list;
        }
    }
}