using Microsoft.AspNetCore.Mvc;
using sportlife.Models;
using sportlife.Services;

namespace sportlife.Controllers
{
    [ApiController]
    [Route("api/club")]
    public class SportClubController : ControllerBase
    {
        private readonly IClubService _service;
        private readonly IMembershipService _membershipService;
        private readonly ITransactionService _transactionService;
        
        public SportClubController(IClubService service, IMembershipService membershipService, ITransactionService transactionService)
        {
            _service = service;
            _membershipService = membershipService;
            _transactionService = transactionService;
        }

        [HttpPost("use{serviceId}/{membershipId}")]
        public ActionResult Use(int serviceId, int membershipId) 
        {
            var membership = _membershipService.Select(membershipId).Result;
            var service = ServicesData.services.Find(service => service.Id == serviceId);
            // _service.Use(service, membership);
            return Ok(_service.Use(service, membership));
        }
    }
}