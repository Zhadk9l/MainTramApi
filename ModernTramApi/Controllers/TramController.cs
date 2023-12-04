using Microsoft.AspNetCore.Mvc;
using ModernTramApi.Clients;
using ModernTramApi.Models;

namespace ModernTramApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TramController : Controller
    {
        private readonly TramClient _tramService;

        public TramController(TramClient tramService)
        {
            _tramService = tramService;
        }

        // GET: api/Tram/GetAllTramsWithTramMove
        [HttpGet("GetAllTramsWithTramMove")]
        public async Task<IEnumerable<MTramWithLastMovement>> GetTrams()
        {
            var trams = await _tramService.GetAllTramsWithLastMovement();
            return trams;
        }


        // GET: api/Tram/GetAllTram
        [HttpGet("GetAllTram")]
        public async Task<IEnumerable<MTram>> GetTram()
        {
            var tram = await _tramService.GetAllTrams();
            return tram;
        }

        // Post:api/Tram/PostTram
        [HttpPost("PostTram")]
        public async Task<IActionResult> AddStaff([FromBody] MTram tram)
        {
            if (tram == null)
            {
                return BadRequest("Invalid tram data");
            }
            await _tramService.AddTramAsync(tram);
            return Ok("Tram added successfully");
        }
        // Post:api/Tram/Delete/{id}
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> RemoveTram(int id)
        {
            var tramToRemove = await _tramService.GetTramByIdAsync(id);

            if (tramToRemove == null)
            {
                return NotFound("Tram not found");
            }

            await _tramService.RemoveStaffAsync(tramToRemove);

            return Ok("Tram removed successfully");
        }

        // Post:api/Tram/UpdateTram
        [HttpPut("UpdateTram")]
        public async Task<IActionResult> UpdateTram([FromBody] MTram tram)
        {
            if (tram == null)
            {
                return BadRequest("Invalid staff data");
            }

            await _tramService.UpdateTramAsync(tram);

            return Ok("StaffMan updated successfully");
        }

        // GET: api/Tram/GetTramsByOperator/{opTgId}
        [HttpGet("GetTramsByOperator/{opTgId}")]
        public async Task<IEnumerable<MTram>> GetTramsByOperator(int opTgId)
        {
            var trams = await _tramService.GetTramsByOperator(opTgId);
            return trams;
        }



    }
}
