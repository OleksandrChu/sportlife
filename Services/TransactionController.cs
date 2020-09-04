using Microsoft.AspNetCore.Mvc;
using sportlife.Models;
using sportlife.Services;

namespace sportlife.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _service;

        public TransactionController(ITransactionService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public ActionResult<Transaction> GetTransactions(int id) 
        {
            return Ok(_service.SelectAll(id).Result);
        }

        [HttpPost("pay")]
        public ActionResult<Transaction> PayTransaction([FromBody] Transaction transaction) 
        {
            transaction.Amount = transaction.Amount * -1;
            return Created("", _service.Create(transaction).Result);
        }

        [HttpPost("top")]
        public ActionResult<Transaction> TopUpTransaction([FromBody] Transaction transaction) 
        {
            return Created("", _service.Create(transaction).Result);
        }
    }
}