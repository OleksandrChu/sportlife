using System;
using Microsoft.AspNetCore.Mvc;
using sportlife.Models;
using sportlife.Services;

namespace sportlife.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authService;
        private readonly IMembershipService _membershipService;
        private readonly IHistoryService _historyService;

        public AuthenticationController(IAuthenticationService authService, IMembershipService membershipService,
                                        IHistoryService historyService)
        {
            _authService = authService;
            _membershipService = membershipService;
            _historyService = historyService;
        }

        [HttpPost("membership/{id}")]
        public ActionResult<ServiceUsageCode> Authenticate(int id)
        {
            var membership = _membershipService.Select(id).Result;
            var auth = _authService.Authenticate(membership);
            if(auth.Equals(ServiceUsageCode.ACCESS_DENIED)) 
            {
                return StatusCode(403, "Access denied");
            }
            _historyService.Create(new VisitHistory(){ MembershipId = membership.Id, visitTime = DateTime.Now});
            return Ok("Confirmed");
        }
    }
}