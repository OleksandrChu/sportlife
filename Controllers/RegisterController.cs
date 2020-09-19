using Microsoft.AspNetCore.Mvc;
using sportlife.Data;
using sportlife.Models;
using sportlife.Builders;
using sportlife.Services;

namespace sportlife.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegisterController : ControllerBase
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

        [HttpPost]
        public ActionResult<Client> tewst([FromBody] Register registerTemplate)
        {
            var account = _accountService.Create(new Account() {Debt = registerTemplate.AccountDebt});
            var membership = _membershipService.Create(new MemberShip()
            {
                Type = (MemberShipType)registerTemplate.MemberShipType,
                Account = account.Result
            });
            var client = _clientService.Create(new Client
            {
                FirstName = registerTemplate.FirstName,
                LastName = registerTemplate.LastName,
                Phone = registerTemplate.Phone,
                MemberShip = membership.Result
            });
            return client.Result;
        }

        [HttpGet]
        public ActionResult<MemberShip> GetMembership(int id)
        {
            return Ok(_membershipService.Select(2).Result);
        }

        
    }
}