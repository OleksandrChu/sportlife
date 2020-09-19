using Microsoft.AspNetCore.Mvc;
using sportlife.Data;
using sportlife.Models;
using sportlife.Builders;
using sportlife.Services;

namespace sportlife.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembershipController : ControllerBase
    {
        private readonly IMembershipService _service;

        public MembershipController(IMembershipService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public ActionResult<MemberShip> GetMembership(int id) 
        {
            return Ok(_service.Select(id).Result);
        }

        [HttpPost]
        public ActionResult<MemberShip> CreateMembership([FromBody] MemberShip memberShip) 
        {
            return Ok(_service.Create(memberShip).Result);
        }

        [HttpPatch("{id}")]
        public ActionResult<MemberShip> UpdateMembershipType(int id, [FromBody] MemberShip memberShip)
        {
            return Ok(_service.Update(id, memberShip.Type).Result);
        }
    }
}