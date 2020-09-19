using Microsoft.AspNetCore.Mvc;
using sportlife.Services;

namespace sportlife.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    class RegisterController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IMembershipService _membershipService;
        private readonly IClientService _clientService;

        public RegisterController(IAccountService accountService, IMembershipService membershipService, IClientService clientService)
        {
            _accountService = accountService;
            _membershipService = membershipService;
            _clientService = clientService;
        }

//        [HttpPost]
        // public IActionResult Register()
        // {

        // }
    }
}