using Microsoft.EntityFrameworkCore;
using ModernTramApi.Db;
using ModernTramApi.Models;
using ModernTramApi.Db;

namespace ModernTramApi.Clients
{
    public class PassengerClient
    {
        private HttpClient _client;
        private readonly ApplicationDbContext _context;

        public PassengerClient(ApplicationDbContext context)
        {
            _context = context;
            _client = new HttpClient();
        }

        public async Task<IEnumerable<MPassenger>> GetAllPassengers()
        {
            var passenger = await _context.Passenger.ToListAsync();

            if (passenger != null)
            {
                return passenger;
            }
            else
            {
                return Enumerable.Empty<MPassenger>();
            }
        }
        public async Task<MPassenger> GetUserByIdAsync(int id)
        {
            return await _context.Passenger.FindAsync(id);
        }
        public async Task AddUserAsync(MPassenger passenger)
        {
            await _context.AddPessengerAsync(passenger);
        }
        public async Task RemoveUserAsync(MPassenger passenger)
        {
            await _context.RemovePassengerAsync(passenger);
        }
    }
}
