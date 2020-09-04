using Microsoft.AspNetCore.Mvc;
using sportlife.Data;
using sportlife.Models;
using sportlife.Services;

namespace sportlife.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public ActionResult<Account> GetAccount(int id) 
        {
            return Ok(_service.Select(id).Result);
        }

        [HttpPost]
        public ActionResult<Account> CreateAccount([FromBody] Account account) 
        {
            return Created("", _service.Create(account).Result);
        }
    }
}