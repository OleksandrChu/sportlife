using Microsoft.AspNetCore.Mvc;
using sportlife.Data;
using sportlife.Models;

namespace sportlife.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembershipController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MembershipController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public ActionResult<MemberShip> GetMembership(int id) 
        {
            return Ok();
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