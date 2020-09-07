using sportlife.Models;

namespace sportlife.Services
{
    public interface IAuthenticationService
    {
        ServiceUsageCode Authenticate(MemberShip memberShip);
    }
}