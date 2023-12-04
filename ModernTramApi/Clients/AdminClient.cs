using Microsoft.EntityFrameworkCore;
using ModernTramApi.Db;
using ModernTramApi.Models;
using ModernTramApi.Db;

namespace ModernTramApi.Clients
{
    public class AdminClient
    {
        private HttpClient _client;
        private readonly ApplicationDbContext _context;

        public AdminClient(ApplicationDbContext context)
        {
            _context = context;
            _client = new HttpClient();
        }

        public async Task<string> IsAdminAsync(int id)
        {
            var admin = await _context.Administrator.FindAsync(id);
            if (admin == null) 
            {
                return "none";
            }
            return admin.AdminPassword;
        }

    }
}
