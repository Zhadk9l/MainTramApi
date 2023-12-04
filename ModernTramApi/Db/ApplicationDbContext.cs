using Microsoft.EntityFrameworkCore;
using ModernTramApi.Models;

namespace ModernTramApi.Db
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MAdministrator> Administrator { get; set; }
        public DbSet<MIncident> Incident { get; set; }
        public DbSet<MMaintenanceLog> MaintenanceLog { get; set; }
        public DbSet<MPassenger> Passenger { get; set; }
        public DbSet<MSchedule> Schedule { get; set; }
        public DbSet<MStop> Stop { get; set; }
        public DbSet<MTechnicalStaff> TechnicalStaff { get; set; }
        public DbSet<MTickets> Tickets { get; set; }
        public DbSet<MTram> Tram { get; set; }
        public DbSet<MTramMovement> TramMovement { get; set; }
        public DbSet<MTramOperator> TramOperator { get; set; }
        public DbSet<MTrRoute> TrRoute { get; set; }


        public async Task AddPessengerAsync(MPassenger passenger)
        {
            if (Passenger.Contains(passenger))
            {
                await SaveChangesAsync();
            }
            else
            {
                Passenger.Add(passenger);
                await SaveChangesAsync();
            }
        }
        public async Task RemovePassengerAsync(MPassenger passenger)
        {
            Passenger.Remove(passenger);
            await SaveChangesAsync();
        }

        public async Task AddTicketAsync(MTickets ticket)
        {
            if (Tickets.Contains(ticket))
            {
                await SaveChangesAsync();
            }
            else
            {
                Tickets.Add(ticket);
                await SaveChangesAsync();
            }
        }

        public async Task RemoveTicketAsync(MTickets ticket)
        {
            Tickets.Remove(ticket);
            await SaveChangesAsync();
        }

        public async Task AddTechnicalStaffAsync(MTechnicalStaff staff)
        {
            if (TechnicalStaff.Contains(staff))
            {
                await SaveChangesAsync();
            }
            else
            {
                TechnicalStaff.Add(staff);
                await SaveChangesAsync();
            }
        }

        public async Task RemoveTechnicalStaffAsync(MTechnicalStaff staff)
        {
            TechnicalStaff.Remove(staff);
            await SaveChangesAsync();
        }

        public async Task AddTramOperatorAsync(MTramOperator operatore)
        {
            if (TramOperator.Contains(operatore))
            {
                await SaveChangesAsync();
            }
            else
            {
                TramOperator.Add(operatore);
                await SaveChangesAsync();
            }
        }

        public async Task RemoveTramOperatorAsync(MTramOperator operatore)
        {
            TramOperator.Remove(operatore);
            await SaveChangesAsync();
        }

        public async Task AddTramAsync(MTram tram)
        {
            if (Tram.Contains(tram))
            {
                await SaveChangesAsync();
            }
            else
            {
                Tram.Add(tram);
                await SaveChangesAsync();
            }
        }

        public async Task RemoveTramAsync(MTram tram)
        {
            Tram.Remove(tram);
            await SaveChangesAsync();
        }

        public async Task AddIncidentAsync(MIncident inc)
        {
            if (Incident.Contains(inc))
            {
                await SaveChangesAsync();
            }
            else
            {
                Incident.Add(inc);
                await SaveChangesAsync();
            }
        }

        public async Task RemoveIncidentAsync(MIncident inc)
        {
            Incident.Remove(inc);
            await SaveChangesAsync();
        }


        public async Task AddLogAsync(MMaintenanceLog log)
        {
            if (MaintenanceLog.Contains(log))
            {
                await SaveChangesAsync();
            }
            else
            {
                MaintenanceLog.Add(log);
                await SaveChangesAsync();
            }
        }

        public async Task RemoveLogAsync(MMaintenanceLog log)
        {
            MaintenanceLog.Remove(log);
            await SaveChangesAsync();
        }


    }
}
