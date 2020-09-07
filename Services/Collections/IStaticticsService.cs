using System.Collections.Generic;
using System.Linq;
using sportlife.Models;

namespace sportlife.Services
{
    public interface IStaticticsService
    {
        IQueryable GetMemberhipByTypeStatictics();

        IQueryable GetUsingServicesStatistics();

        Dictionary<int, List<VisitHistory>> GetVisitClubStatistics();
    }
}