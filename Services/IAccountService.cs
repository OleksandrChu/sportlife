using System.Threading.Tasks;
using sportlife.Models;

namespace sportlife.Services
{
    public interface IAccountService
    {
         Task<Account> Create(Account model);

        Task<Account> Select(int id);
    }
}