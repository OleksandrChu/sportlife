using System.Threading.Tasks;
using sportlife.Models;

namespace sportlife.Services
{
    public interface IHistoryService
    {
         Task<ServiceHistory> Create(ServiceHistory model);
    }
}