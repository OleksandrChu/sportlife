using System.Threading.Tasks;
using sportlife.Models;

namespace sportlife.Services
{
    public interface IMembershipService
    {
        Task<MemberShip> Create(MemberShip model);

        Task<MemberShip> Select(int id);
    }
}