using sportlife.Models;

namespace sportlife.Services
{
    public interface IAuthenticationService
    {
        ResponceType Authenticate(MemberShip memberShip);
    }
}