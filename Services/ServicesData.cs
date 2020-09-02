using System.Collections.Generic;
using sportlife.Models;

namespace sportlife.Services
{
    public static class ServicesData
    {
        private static Service PoolService = new Service("Pool");
        private static Service GymService = new Service("Gym");
        private static Service GroupService = new Service("Group");
        private static Service SpaService = new Service("SPA");
        public static Dictionary<MemberShipType, List<Service>> services = new Dictionary<MemberShipType, List<Service>>()
        {
            {MemberShipType.CLASSIC, new List<Service>{ GymService, GroupService} },
            {MemberShipType.CLASSIC_POOL, new List<Service>{ GymService, GroupService , PoolService} },
            {MemberShipType.PREMIUM, new List<Service>{ GymService, GroupService , PoolService, SpaService} },
        };
    }
}