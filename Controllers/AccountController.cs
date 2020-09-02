using Microsoft.AspNetCore.Mvc;
using sportlife.Data;
using sportlife.Models;

namespace sportlife.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public ActionResult<Account> GetAccount(int id) 
        {
            return Ok();
        }

        [HttpPost]
        public ActionResult<Account> CreateAccount([FromBody] Account account) 
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
            return Ok(account);
        }
    }
}