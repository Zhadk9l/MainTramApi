using Microsoft.AspNetCore.Mvc;
using ModernTramApi.Clients;
using ModernTramApi.Models;

namespace ModernTramApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : Controller
    {
        private readonly ScheduleClient _scheduleService;

        public ScheduleController(ScheduleClient scheduleService)
        {
            _scheduleService = scheduleService;
        }

        // GET: api/Schedule/
        [HttpGet("GetAllSchedule")]
        public async Task<IEnumerable<MScheduleWithRouteAndOperator>> GetScheduleWithRouteAndOperator()
        {
            var schedule = await _scheduleService.GetAllScheduleWithRouteAndOperator();
            return schedule;
        }

        // GET: api/Schedule/GetScheduleByOperator/{operatorId}
        [HttpGet("GetScheduleByOperator/{operatorId}")]
        public async Task<IEnumerable<MScheduleWithRouteAndOperator>> GetScheduleByOperator(int operatorId)
        {
            var schedule = await _scheduleService.GetScheduleByOperator(operatorId);
            return schedule;
        }

    }
}
