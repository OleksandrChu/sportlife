using System.Collections.Generic;
using System.Threading.Tasks;
using sportlife.Models;

namespace sportlife.Services
{
    public interface IHistoryService
    {
         Task<ServiceHistory> Create(ServiceHistory model);

         Task<List<ServiceHistory>> SelectAll();

         Task<VisitHistory> Create(VisitHistory model);
    }
}