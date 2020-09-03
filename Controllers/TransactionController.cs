using Microsoft.AspNetCore.Mvc;
using sportlife.Models;
using sportlife.Repositories;

namespace sportlife.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly TransactionRepository _repository;

        public TransactionController(IRepository<Transaction> repository)
        {
            _repository = (TransactionRepository)repository;
        }

        [HttpGet("{id}")]
        public ActionResult<Transaction> GetTransactions(int id) 
        {
            return Ok(_repository.Select(id).Result);
        }

        [HttpPost("pay")]
        public ActionResult<Transaction> PayTransaction([FromBody] Transaction transaction) 
        {
            transaction.Amount = transaction.Amount * -1;
            return Created("", _repository.Create(transaction).Result);
        }

        [HttpPost("top")]
        public ActionResult<Transaction> TopUpTransaction([FromBody] Transaction transaction) 
        {
            return Created("", _repository.Create(transaction).Result);
        }
    }
}