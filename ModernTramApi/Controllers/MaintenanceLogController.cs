using Microsoft.AspNetCore.Mvc;
using ModernTramApi.Clients;
using ModernTramApi.Models;

namespace ModernTramApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaintenanceLogController : Controller
    {
        private readonly MaintenanceLogClient _logService;

        public MaintenanceLogController(MaintenanceLogClient maintenanceLogService)
        {
            _logService = maintenanceLogService;
        }


        // GET: api/Logs/GetAllLogs
        [HttpGet("GetAllLogs")]
        public async Task<IEnumerable<MMaintenanceLog>> GetStaff()
        {
            var log = await _logService.GetAllLogs();
            return log;
        }

        // Post:api/Logs/PostStaff
        [HttpPost("PostLogs")]
        public async Task<IActionResult> AddLogs([FromBody] MMaintenanceLog log)
        {
            if (log == null)
            {
                return BadRequest("Invalid log data");
            }
            await _logService.AddLogAsync(log);
            return Ok("Log added successfully");
        }
        // Post:api/Logs/Delete/{id}
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> RemoveLog(int id)
        {
            var staffToRemove = await _logService.GetLogByIdAsync(id);

            if (staffToRemove == null)
            {
                return NotFound("Log not found");
            }

            await _logService.RemoveLogAsync(staffToRemove);

            return Ok("Log removed successfully");
        }
        // Post:api/Logs/UpdateLog
        [HttpPut("UpdateLogs")]
        public async Task<IActionResult> UpdateStaff([FromBody] MMaintenanceLog log)
        {
            if (log == null)
            {
                return BadRequest("Invalid staff data");
            }

            await _logService.UpdateStaffAsync(log);

            return Ok("Log updated successfully");
        }

    }
}
