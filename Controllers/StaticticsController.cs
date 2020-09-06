using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sportlife.Data;
using sportlife.Models;
using sportlife.Services;

namespace sportlife.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StaticticsController : ControllerBase
    {
        private readonly IStaticticsService _statisticsService;

        public StaticticsController(IStaticticsService staticticsService)
        {
            _statisticsService = staticticsService;
        }

        [HttpGet]
        public ActionResult GetStat() 
        {
            // SELECT type, COUNT(type) FROM Memberships GROUP BY type
            return Ok(_statisticsService.GetMemberhipByTypeStatictics());
        }

        [HttpGet("1")]
        public ActionResult GetSta1t() 
        {
            return Ok(_statisticsService.GetUsingServicesStatistics());
        }
    }
}