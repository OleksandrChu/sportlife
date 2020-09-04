using System.Collections.Generic;
using sportlife.Models;

namespace sportlife.Services
{
    public static class ServicesData
    {
        private static Service PoolService = new Service(1, "Pool", 200);
        private static Service GymService = new Service(2, "Gym", 200);
        private static Service GroupService = new Service(3, "Group", 150);
        private static Service SpaService = new Service(4, "SPA", 150);

        public static List<Service> services = new List<Service>() { PoolService, GymService, GroupService, SpaService };
        public static Dictionary<MemberShipType, List<Service>> memberships = new Dictionary<MemberShipType, List<Service>>()
        {
            {MemberShipType.CLASSIC, new List<Service>{ GymService, GroupService} },
            {MemberShipType.CLASSIC_POOL, new List<Service>{ GymService, GroupService , PoolService} },
            {MemberShipType.PREMIUM, new List<Service>{ GymService, GroupService , PoolService, SpaService} },
        };
    }
}