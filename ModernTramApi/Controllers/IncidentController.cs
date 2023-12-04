using Microsoft.AspNetCore.Mvc;
using ModernTramApi.Clients;
using ModernTramApi.Models;

namespace ModernTramApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentController : Controller
    {
        private readonly IncidentClient _incidentService;

        public IncidentController(IncidentClient incidentService)
        {
            _incidentService = incidentService;
        }

        // GET: api/Incident/
        [HttpGet("GetAllTodayIncident")]
        public async Task<IEnumerable<MIncident>> GetTodayIncident()
        {
            var incidents = await _incidentService.GetAllTodayIncident();
            return incidents;
        }
        // PUT: api/Incident/UpdateIncident
        [HttpPut("UpdateIncident")]
        public async Task<IActionResult> UpdateIncident([FromBody] MIncident updatedIncident)
        {
            if (ModelState.IsValid)
            {
                var result = await _incidentService.UpdateIncident(updatedIncident);

                if (result)
                {
                    return Ok("Incident updated successfully");
                }
                else
                {
                    return NotFound("Incident not found");
                }
            }

            return BadRequest(ModelState);
        }
        // GET: api/Incident/GetAllIncidents
        [HttpGet("GetAllIncidents")]
        public async Task<IEnumerable<MIncident>> GetIncidents()
        {
            var incidents = await _incidentService.GetAllIncidents();
            return incidents;
        }


        // POST: api/Incident/AddIncident
        [HttpPost("AddIncident")]
        public async Task<IActionResult> AddIncident([FromBody] MIncident incident)
        {
            if (incident == null)
            {
                return BadRequest("Invalid incident data");
            }

            await _incidentService.AddIncidentAsync(incident);
            return Ok("Incident added successfully");
        }

        // DELETE: api/Incident/RemoveIncident/{id}
        [HttpDelete("RemoveIncident/{id}")]
        public async Task<IActionResult> RemoveIncident(int id)
        {
            var incidentToRemove = await _incidentService.GetIncidentByIdAsync(id);

            if (incidentToRemove == null)
            {
                return NotFound("Incident not found");
            }

            await _incidentService.RemoveIncidentAsync(incidentToRemove);

            return Ok("Incident removed successfully");
        }

    }
}
