using System.Threading.Tasks;
using sportlife.Models;

namespace sportlife.Services
{
    public interface IClientService
    {
        Task<Client> Create(Client model);

        Task<Client> Select(int id);
    }
}