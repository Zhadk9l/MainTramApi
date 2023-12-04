using Microsoft.EntityFrameworkCore;
using ModernTramApi.Db;
using ModernTramApi.Models;
using ModernTramApi.Db;

namespace ModernTramApi.Clients
{
    public class TramClient
    {
        private HttpClient _client;
        private readonly ApplicationDbContext _context;

        public TramClient(ApplicationDbContext context)
        {
            _context = context;
            _client = new HttpClient();
        }

        public async Task<IEnumerable<MTramWithLastMovement>> GetAllTramsWithLastMovement()
        {
            // Получаем все данные из базы данных
            var allTramsWithMovement = await _context.TramMovement
                .Join(_context.Tram, tm => tm.TramId, tram => tram.Id, (tm, tram) => new MTramWithLastMovement
                {
                    Id = tram.Id,
                    BrandAndModel = tram.BrandAndModel,
                    Condition = tram.Condition,
                    LastMovementDateTime = tm.DateTime,
                    LastMovementCoordinates = tm.Coordinates,
                    LastMovementSpeed = tm.Speed,
                    LastMovementDirection = tm.Direction
                })
                .ToListAsync();

            // Группируем данные по Id и выбираем записи с максимальной датой в каждой группе
            var tramsWithLatestMovement = allTramsWithMovement
                .GroupBy(t => t.Id)
                .Select(group => group.OrderByDescending(t => t.LastMovementDateTime).First())
                .ToList();

            return tramsWithLatestMovement;
        }

        


        public async Task<IEnumerable<MTram>> GetAllTrams()
        {
            var tram = await _context.Tram.ToListAsync();

            if (tram != null)
            {
                return tram;
            }
            else
            {
                return Enumerable.Empty<MTram>();
            }
        }
        public async Task<MTram> GetTramByIdAsync(int id)
        {
            return await _context.Tram.FindAsync(id);
        }
        public async Task AddTramAsync(MTram tram)
        {
            await _context.AddTramAsync(tram);
        }
        public async Task RemoveStaffAsync(MTram tram)
        {
            await _context.RemoveTramAsync(tram);
        }

        public async Task UpdateTramAsync(MTram tram)
        {
            var existingTram = await _context.Tram.FindAsync(tram.Id);

            if (existingTram != null)
            {
                existingTram.Id = tram.Id;
                existingTram.BrandAndModel = tram.BrandAndModel;
                existingTram.Condition = tram.Condition;


                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<MTram>> GetTramsByOperator(int opTgId)
        {
            var trams = await _context.Schedule
                .Where(schedule => schedule.OpTgID == opTgId)
                .Join(_context.Tram, schedule => schedule.TramID, tram => tram.Id, (schedule, tram) => new MTram
                {
                    Id = tram.Id,
                    BrandAndModel = tram.BrandAndModel,
                    Condition = tram.Condition
                })
                .ToListAsync();


            return trams;
        }




    }
}
