using Microsoft.AspNetCore.Mvc;
using ModernTramApi.Clients;
using ModernTramApi.Models;

namespace ModernTramApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : Controller
    {
        private readonly PassengerClient _passengerService;

        public PassengerController(PassengerClient passengerService)
        {
            _passengerService = passengerService;
        }

        // GET: api/Passenger/GetAll
        [HttpGet("GetAll")]
        public async Task<IEnumerable<MPassenger>> GetPassengers()
        {
            var passengers = await _passengerService.GetAllPassengers();
            return passengers;
        }
        // Post:api/Passenger/PostPassenger
        [HttpPost("PostPassenger")]
        public async Task<IActionResult> AddPassenger([FromBody] MPassenger passenger)
        {
            if (passenger == null)
            {
                return BadRequest("Invalid user data");
            }
            await _passengerService.AddUserAsync(passenger);
            return Ok("Passenger added successfully");
        }
        // Post:api/Passenger/Delete/{id}
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> RemoveUser(int id)
        {
            var passengerToRemove = await _passengerService.GetUserByIdAsync(id);

            if (passengerToRemove == null)
            {
                return NotFound("Passenger not found");
            }

            await _passengerService.RemoveUserAsync(passengerToRemove);

            return Ok("Passenger removed successfully");
        }
    }
}
