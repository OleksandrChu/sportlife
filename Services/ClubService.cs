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
        public ResponceType Use(Service service, MemberShip memberShip)
        {
            var accountBalance = _context.Accounts
                                .Where(account => account.Id == memberShip.Account.Id)
                                .First().Balance;
            var IsInclude = IsServiceIncude(service, memberShip);
            return BuildResponse(IsInclude, accountBalance, service.Price);
        }

        private bool IsServiceIncude(Service service, MemberShip memberShip)
        {
            return (memberShip.Services.Find(s => s.Title.Equals(s)) != null);
        }

        private ResponceType BuildResponse(bool IsInclude, int accountBalance, int servicePrice)
        {
            if(!IsInclude && accountBalance >= servicePrice) 
            {
                return ResponceType.PAID;
            }
            else if(!IsInclude && accountBalance < servicePrice) 
            {
                return ResponceType.NEED_TOP_UP_ACCOUNT;
            }
            return ResponceType.CONFIRMED;
        }
    }
}