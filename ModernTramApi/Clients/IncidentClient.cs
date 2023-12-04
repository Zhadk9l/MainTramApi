using Microsoft.EntityFrameworkCore;
using ModernTramApi.Db;
using ModernTramApi.Models;
using ModernTramApi.Db;

namespace ModernTramApi.Clients
{
    public class IncidentClient
    {
        private HttpClient _client;
        private readonly ApplicationDbContext _context;

        public IncidentClient(ApplicationDbContext context)
        {
            _context = context;
            _client = new HttpClient();
        }

        public async Task<IEnumerable<MIncident>> GetAllTodayIncident()
        {
            DateTime today = DateTime.Now.Date;

            var incidents = await _context.Incident
                                        .Where(incident => incident.IncDateTime.Date == today)
                                        .ToListAsync();

            if (incidents != null)
            {
                return incidents;
            }
            else
            {
                return Enumerable.Empty<MIncident>();
            }
        }
        public async Task<bool> UpdateIncident(MIncident updatedIncident)
        {
            var existingIncident = await _context.Incident.FindAsync(updatedIncident.ID);

            if (existingIncident != null)
            {
                // Обновление данных инцидента
                existingIncident.IncDateTime = updatedIncident.IncDateTime;
                existingIncident.IncDescription = updatedIncident.IncDescription;
                existingIncident.IncStatus = updatedIncident.IncStatus;
                existingIncident.TramID = updatedIncident.TramID;

                await _context.SaveChangesAsync();

                return true; // Обновление успешно
            }

            return false; // Инцидент не найден
        }
        public async Task<IEnumerable<MIncident>> GetAllIncidents()
        {
            var incidents = await _context.Incident.ToListAsync();

            if (incidents != null)
            {
                return incidents;
            }
            else
            {
                return Enumerable.Empty<MIncident>();
            }
        }

        public async Task<MIncident> GetIncidentByIdAsync(int id)
        {
            return await _context.Incident.FindAsync(id);
        }

        public async Task AddIncidentAsync(MIncident incident)
        {
            await _context.AddIncidentAsync(incident);
        }

        public async Task RemoveIncidentAsync(MIncident incident)
        {
            await _context.RemoveIncidentAsync(incident);
        }

    }
}
