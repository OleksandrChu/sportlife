using sportlife.Models;

namespace sportlife.Builders
{
    public interface IMembershipBuilder
    {
        void IncludeServicesTo(MemberShip memberShip);
    }
}