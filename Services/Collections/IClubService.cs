using sportlife.Models;

namespace sportlife.Services
{
    public interface IClubService
    {
        ServiceUsageCode Use(Service service, MemberShip memberShip);
    }
}