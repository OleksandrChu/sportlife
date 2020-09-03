using Microsoft.AspNetCore.Mvc;
using sportlife.Models;
using sportlife.Repositories;

namespace sportlife.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly IRepository<Transaction> _repository;

        public TransactionController(IRepository<Transaction> context)
        {
            _repository = context;
        }

        [HttpGet("{id}")]
        public ActionResult<Transaction> GetTransactions(int id) 
        {
            return Ok(_repository.Select(id).Result);
        }

        [HttpPost]
        public ActionResult<Account> CreateAccount([FromBody] Transaction transaction) 
        {
            return Created("", _repository.Create(transaction).Result);
        }
    }
}