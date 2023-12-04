using Microsoft.EntityFrameworkCore;
using ModernTramApi.Db;
using ModernTramApi.Models;
using ModernTramApi.Db;

namespace ModernTramApi.Clients
{
    public class MaintenanceLogClient
    {
        private HttpClient _client;
        private readonly ApplicationDbContext _context;

        public MaintenanceLogClient(ApplicationDbContext context)
        {
            _context = context;
            _client = new HttpClient();
        }

        public async Task<IEnumerable<MMaintenanceLog>> GetAllLogs()
        {
            var log = await _context.MaintenanceLog.ToListAsync();

            if (log != null)
            {
                return log;
            }
            else
            {
                return Enumerable.Empty<MMaintenanceLog>();
            }
        }
        public async Task<MMaintenanceLog> GetLogByIdAsync(int id)
        {
            return await _context.MaintenanceLog.FindAsync(id);
        }
        public async Task AddLogAsync(MMaintenanceLog log)
        {
            await _context.AddLogAsync(log);
        }
        public async Task RemoveLogAsync(MMaintenanceLog log)
        {
            await _context.RemoveLogAsync(log);
        }

        public async Task UpdateStaffAsync(MMaintenanceLog log)
        {
            var existLog = await _context.MaintenanceLog.FindAsync(log.ID);

            if (existLog != null)
            {
                existLog.ID = log.ID;
                existLog.ScheduledService = log.ScheduledService;
                existLog.RepairDescription = log.RepairDescription;
                existLog.TechnicalStaff = log.TechnicalStaff;


                await _context.SaveChangesAsync();
            }
        }

    }
}
