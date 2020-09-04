using sportlife.Models;
using sportlife.Services;

namespace sportlife.Builders
{
    public class MembershipBuilder : IMembershipBuilder
    {
        public void IncludeServicesTo(MemberShip memberShip)
        {
            memberShip.Services = ServicesData.memberships[memberShip.Type];
        }
    }
}