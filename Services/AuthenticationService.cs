using System;
using System.Linq;
using sportlife.Data;
using sportlife.Models;

namespace sportlife.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ApplicationDbContext _context;
        
        public AuthenticationService(ApplicationDbContext context)
        {
            _context = context;
        }
        public ResponceTypes Authenticate(MemberShip memberShip)
        {
            var accountBalance = _context.Accounts
                                .Where(account => account.Id == memberShip.Account.Id)
                                .First().Balance;
            return (IsNotExpired(memberShip.ExpirationDate) && accountBalance > 0) ? ResponceTypes.CONFIRMED : ResponceTypes.ACCESS_DENIED;
        }

        private bool IsNotExpired(DateTime expirationDate)
        {
            TimeSpan timeSpan = expirationDate - DateTime.Now;
            return timeSpan.Days >= 0;
        }
    }
}