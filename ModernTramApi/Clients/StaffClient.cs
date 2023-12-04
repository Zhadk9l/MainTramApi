using Microsoft.EntityFrameworkCore;
using ModernTramApi.Db;
using ModernTramApi.Models;
using ModernTramApi.Db;

namespace ModernTramApi.Clients
{
    public class StaffClient
    {
        private HttpClient _client;
        private readonly ApplicationDbContext _context;

        public StaffClient(ApplicationDbContext context)
        {
            _context = context;
            _client = new HttpClient();
        }

        public async Task<string> IsStaffAsync(int id)
        {
            var staff = await _context.TechnicalStaff.FindAsync(id);
            if (staff == null) 
            {
                return "none";
            }
            return staff.TechnicalStaffPassword;
        }
        public async Task<IEnumerable<MTechnicalStaff>> GetAllStaff()
        {
            var staff = await _context.TechnicalStaff.ToListAsync();

            if (staff != null)
            {
                return staff;
            }
            else
            {
                return Enumerable.Empty<MTechnicalStaff>();
            }
        }
        public async Task<MTechnicalStaff> GetStaffByIdAsync(int id)
        {
            return await _context.TechnicalStaff.FindAsync(id);
        }
        public async Task AddStaffAsync(MTechnicalStaff staff)
        {
            await _context.AddTechnicalStaffAsync(staff);
        }
        public async Task RemoveStaffAsync(MTechnicalStaff staff)
        {
            await _context.RemoveTechnicalStaffAsync(staff);
        }
        public async Task UpdateStaffAsync(MTechnicalStaff staff)
        {
            var existingStaff = await _context.TechnicalStaff.FindAsync(staff.ID);

            if (existingStaff != null)
            {
                existingStaff.ID = staff.ID;
                existingStaff.Position = staff.Position;
                existingStaff.Qualification = staff.Qualification;
                existingStaff.TechnicalStaffPassword = staff.TechnicalStaffPassword;


                await _context.SaveChangesAsync();
            }
        }
    }
}
