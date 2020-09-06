using System.Linq;
using sportlife.Data;
using sportlife.Models;

namespace sportlife.Services
{
    public class ClubService : IClubService
    {
        private readonly ApplicationDbContext _context;

        public ClubService(ApplicationDbContext context)
        {
            _context = context;
        }
        public ServiceUsageCode Use(Service service, MemberShip memberShip)
        {
            var IsInclude = IsServiceIncude(service, memberShip);
            return BuildResponse(IsInclude, memberShip.Account.Balance, service.Price);
        }

        private bool IsServiceIncude(Service service, MemberShip memberShip)
        {
            return (memberShip.Services.Find(s => s.Title.Equals(service.Title)) != null);
        }

        private ServiceUsageCode BuildResponse(bool IsInclude, int accountBalance, int servicePrice)
        {
            if(!IsInclude && accountBalance >= servicePrice) 
            {
                return ServiceUsageCode.PAID;
            }
            else if(!IsInclude && accountBalance < servicePrice) 
            {
                return ServiceUsageCode.NEED_TOP_UP_ACCOUNT;
            }
            return ServiceUsageCode.CONFIRMED;
        }
    }
}