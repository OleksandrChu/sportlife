using Microsoft.AspNetCore.Mvc;
using sportlife.Data;
using sportlife.Models;
using sportlife.Builders;

namespace sportlife.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembershipController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMembershipBuilder _builder;

        public MembershipController(ApplicationDbContext context, IMembershipBuilder builder)
        {
            _context = context;
            _builder = builder;
        }

        [HttpGet("{id}")]
        public ActionResult<MemberShip> GetMembership(int id) 
        {
            var memberShip =_context.Memberships.Find(id);
            _builder.Build(memberShip);
            return Ok(_context.Memberships.Find(id));
        }

        [HttpPost]
        public ActionResult<MemberShip> CreateMembership([FromBody] MemberShip memberShip) 
        {
            _context.Memberships.Add(memberShip);
            _context.SaveChanges();
            return Ok(memberShip);
        }
    }
}