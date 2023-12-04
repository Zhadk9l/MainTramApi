using Microsoft.EntityFrameworkCore;
using ModernTramApi.Db;
using ModernTramApi.Models;
using ModernTramApi.Db;

namespace ModernTramApi.Clients
{
    public class TicketClient
    {
        private HttpClient _client;
        private readonly ApplicationDbContext _context;

        public TicketClient(ApplicationDbContext context)
        {
            _context = context;
            _client = new HttpClient();
        }

        public async Task<IEnumerable<MTickets>> GetAllTicketsForPessengare(int passTgId)
        {
            var tickets = await _context.Tickets.Where(ticket => ticket.TgID == passTgId)
                                .ToListAsync();

            if (tickets != null)
            {
                return tickets;
            }
            else
            {
                return Enumerable.Empty<MTickets>();
            }
        }
        public async Task<IEnumerable<MTickets>> GetAllTickets()
        {
            var tickets = await _context.Tickets.ToListAsync();

            if (tickets != null)
            {
                return tickets;
            }
            else
            {
                return Enumerable.Empty<MTickets>();
            }
        }
        public async Task<MTickets> GetTicketByIdAsync(int id)
        {
            return await _context.Tickets.FindAsync(id);
        }
        public async Task AddTicketAsync(MTickets ticket)
        {
            await _context.AddTicketAsync(ticket);
        }
        public async Task RemoveTicketAsync(MTickets ticket)
        {
            await _context.RemoveTicketAsync(ticket);
        }

    }
}
