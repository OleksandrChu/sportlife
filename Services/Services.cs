using System.Collections.Generic;
using sportlife.Models;

namespace sportlife.Services
{
    public class Services
    {
        private static Service PoolService = new Service("Pool");
        private static Service GymService = new Service("Gym");
        private static Service GroupService = new Service("Group");
        private static Service SpaService = new Service("SPA");
        public static List<Service> ClassicServices = new List<Service> { GymService, GroupService };
        public static List<Service> ClassicPoolServices = new List<Service>{ GymService, GroupService , PoolService};
        public static List<Service> PremiumServices = new List<Service>{ GymService, GroupService , PoolService, SpaService};
    }
}