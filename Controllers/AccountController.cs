using Microsoft.AspNetCore.Mvc;
using sportlife.Data;
using sportlife.Models;
using sportlife.Repositories;

namespace sportlife.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IRepository<Account> _context;

        public AccountController(IRepository<Account> context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public ActionResult<Account> GetAccount(int id) 
        {
            return Ok(_context.Select(id).Result);
        }

        [HttpPost]
        public ActionResult<Account> CreateAccount([FromBody] Account account) 
        {
            return Ok(_context.Create(account).Result);
        }
    }
}