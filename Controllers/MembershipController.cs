using Microsoft.AspNetCore.Mvc;
using sportlife.Data;
using sportlife.Models;
using sportlife.Builders;
using sportlife.Repositories;

namespace sportlife.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembershipController : ControllerBase
    {
        private readonly IRepository<MemberShip> _context;

        public MembershipController(IRepository<MemberShip> context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public ActionResult<MemberShip> GetMembership(int id) 
        {
            return Ok(_context.Select(id).Result);
        }

        [HttpPost]
        public ActionResult<MemberShip> CreateMembership([FromBody] MemberShip memberShip) 
        {
            return Ok(_context.Create(memberShip).Result);
        }
    }
}