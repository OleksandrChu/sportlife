using sportlife.Models;
using sportlife.Services;

namespace sportlife.Builders
{
    public class MembershipBuilder : IMembershipBuilder
    {
        public void Build(MemberShip memberShip)
        {
            memberShip.Services = ServicesData.services[memberShip.Type];
        }
    }
}