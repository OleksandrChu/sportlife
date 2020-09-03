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
        private readonly AccountRepository _repository;

        public AccountController(IRepository<Account> repository)
        {
            _repository = (AccountRepository)repository;
        }

        [HttpGet("{id}")]
        public ActionResult<Account> GetAccount(int id) 
        {
            return Ok(_repository.Select(id).Result);
        }

        [HttpPost]
        public ActionResult<Account> CreateAccount([FromBody] Account account) 
        {
            return Created("", _repository.Create(account).Result);
        }
    }
}