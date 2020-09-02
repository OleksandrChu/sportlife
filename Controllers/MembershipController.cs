using Microsoft.AspNetCore.Mvc;
using sportlife.Data;
using sportlife.Models;

namespace sportlife.Controllers
{
    [ApiController]
    [Route("api")]
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
    }
}