using sportlife.Models;

namespace sportlife.Services
{
    public interface IAuthenticationService
    {
        ResponceTypes Authenticate(MemberShip memberShip);
    }
}