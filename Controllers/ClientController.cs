using Microsoft.AspNetCore.Mvc;
using sportlife.Models;
using sportlife.Services;

namespace sportlife.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _service;

        public ClientController(IClientService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public ActionResult<Client> GetAccount(int id)
        {
            return Ok(_service.Select(id).Result);
        }

        [HttpPost]
        public ActionResult<Client> CreateAccount([FromBody] Client client)
        {
            return Created("", _service.Create(client).Result);
        }
    }
}