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
        public ActionResult GetMemberhipByTypeStatictics() 
        {
            return Ok(_statisticsService.GetMemberhipByTypeStatictics());
        }

        [HttpGet("service")]
        public ActionResult GetUsingServicesStatistics() 
        {
            return Ok(_statisticsService.GetUsingServicesStatistics());
        }

        [HttpGet("visit")]
        public ActionResult GetVisitClubStatistics() 
        {
            return Ok(_statisticsService.GetVisitClubStatistics());
        }
    }
}