using Microsoft.AspNetCore.Mvc;
using ModernTramApi.Clients;
using ModernTramApi.Models;

namespace ModernTramApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : Controller
    {
        private readonly StaffClient _staffService;

        public StaffController(StaffClient staffService)
        {
            _staffService = staffService;
        }


        // GET: api/Staff/GetAllStaff
        [HttpGet("GetAllStaff")]
        public async Task<IEnumerable<MTechnicalStaff>> GetStaff()
        {
            var staff = await _staffService.GetAllStaff();
            return staff;
        }
        // GET: api/Staff/IsStaff
        [HttpGet("IsStaff/{id}")]
        public async Task<string> GetStaff(int id)
        {
            string pass = await _staffService.IsStaffAsync(id);
            return pass;
        }

        // Post:api/Staff/PostStaff
        [HttpPost("PostStaff")]
        public async Task<IActionResult> AddStaff([FromBody] MTechnicalStaff staff)
        {
            if (staff == null)
            {
                return BadRequest("Invalid ticket data");
            }
            await _staffService.AddStaffAsync(staff);
            return Ok("StaffMan added successfully");
        }
        // Post:api/Staff/Delete/{id}
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> RemoveStaff(int id)
        {
            var staffToRemove = await _staffService.GetStaffByIdAsync(id);

            if (staffToRemove == null)
            {
                return NotFound("StaffMan not found");
            }

            await _staffService.RemoveStaffAsync(staffToRemove);

            return Ok("StaffMan removed successfully");
        }
        // Post:api/Staff/UpdateStaff
        [HttpPut("UpdateStaff")]
        public async Task<IActionResult> UpdateStaff([FromBody] MTechnicalStaff staff)
        {
            if (staff == null)
            {
                return BadRequest("Invalid staff data");
            }

            await _staffService.UpdateStaffAsync(staff);

            return Ok("StaffMan updated successfully");
        }

    }
}
