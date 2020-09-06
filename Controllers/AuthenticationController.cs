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

        public AuthenticationController(IAuthenticationService authService, IMembershipService membershipService)
        {
            _authService = authService;
            _membershipService = membershipService;
        }

        [HttpPost("membership/{id}")]
        public ActionResult<ServiceUsageCode> Authenticate(int id)
        {
            var auth = _authService.Authenticate(_membershipService.Select(id).Result);
            if(auth.Equals(ServiceUsageCode.ACCESS_DENIED)) 
            {
                return StatusCode(403, "Access denied");
            }
            return Ok("Confirmed");
        }
    }
}