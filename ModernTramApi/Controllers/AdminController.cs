using Microsoft.AspNetCore.Mvc;
using ModernTramApi.Clients;
using ModernTramApi.Models;

namespace ModernTramApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly AdminClient _adminService;

        public AdminController(AdminClient adminService)
        {
            _adminService = adminService;
        }

        // GET: api/Admin/IsAdmin
        [HttpGet("IsAdmin/{id}")]
        public async Task<string> GetAdmin(int id)
        {
            string pass = await _adminService.IsAdminAsync(id);
            return pass;
        }
       
    }
}
