using Microsoft.AspNetCore.Mvc;
using sportlife.Models;
using sportlife.Services;

namespace sportlife.Controllers
{
    [ApiController]
    [Route("api/passes")]
    public class SportClubController : ControllerBase
    {
        private readonly IClubService _clubService;
        private readonly IMembershipService _membershipService;
        private readonly ITransactionService _transactionService;
        private readonly IAccountService _accountService;
        private readonly IHistoryService _historyService;
        
        public SportClubController(IClubService service, IMembershipService membershipService,
                                   ITransactionService transactionService, IAccountService accountService,
                                   IHistoryService historyService)
        {
            _clubService = service;
            _membershipService = membershipService;
            _transactionService = transactionService;
            _accountService = accountService;
            _historyService = historyService;
        }

        [HttpPost("use/{serviceId}/{membershipId}")]
        public ActionResult Use(int serviceId, int membershipId) 
        {
           
            var membership = _membershipService.Select(membershipId).Result;
            membership.Account = _accountService.Select(membership.Account.Id).Result;
            var service = ServicesData.services.Find(service => service.Id == serviceId);
            var serviceUsage = _clubService.Use(service, membership);
            if(serviceUsage.Equals(ServiceUsageCode.NEED_TOP_UP_ACCOUNT))
            {
                return StatusCode(402, "Not enough funds. Need to top up account");
            }
            if(serviceUsage.Equals(ServiceUsageCode.PAID))
            {
                _transactionService.Create(new Transaction()
                {
                    AccountId = membership.Account.Id,
                    Amount = service.Price * - 1,
                    Description = $"Paid {service.Price} credits for {service.Title} service."
                });
                _historyService.Create(new ServiceHistory(){MemberShipType = membership.Type, ServiceId = service.Id});
                return Created("", "Paid"); 
            }
            _historyService.Create(new ServiceHistory(){MemberShipType = membership.Type, ServiceId = service.Id});
            return Ok("Confirmed");
        }
    }
}