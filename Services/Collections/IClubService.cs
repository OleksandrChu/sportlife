using sportlife.Models;

namespace sportlife.Services
{
    public interface IClubService
    {
        ResponceType Use(Service service, MemberShip memberShip);
    }
}