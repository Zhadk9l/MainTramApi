using Microsoft.EntityFrameworkCore;
using ModernTramApi.Db;
using ModernTramApi.Models;
using ModernTramApi.Db;

namespace ModernTramApi.Clients
{
    public class ScheduleClient
    {
        private HttpClient _client;
        private readonly ApplicationDbContext _context;

        public ScheduleClient(ApplicationDbContext context)
        {
            _context = context;
            _client = new HttpClient();
        }

        public async Task<IEnumerable<MScheduleWithRouteAndOperator>> GetAllScheduleWithRouteAndOperator()
        {
            var scheduleWithRouteAndOperator = await _context.Schedule
                .Join(_context.TrRoute, schedule => schedule.RouteID, route => route.ID, (schedule, route) => new { schedule, route })
                .Join(_context.TramOperator, result => result.schedule.OpTgID, tramOperator => tramOperator.OpTgID, (result, tramOperator) => new MScheduleWithRouteAndOperator
                {
                    ID = result.schedule.ID,
                    TramID = result.schedule.TramID,
                    Weekdays = result.schedule.Weekdays,
                    DepartureTime = result.schedule.DepartureTime,
                    RouteName = result.route.Name,
                    RoutLength = result.route.RoutLength,
                    Duration = result.route.Duration,
                    OperatorName = tramOperator.Name,
                    OperatorTgName = tramOperator.TgName,
                })
                .ToListAsync();

            return scheduleWithRouteAndOperator;
        }

        public async Task<IEnumerable<MScheduleWithRouteAndOperator>> GetScheduleByOperator(int operatorId)
        {
            var scheduleWithStopsByOperator = await _context.Schedule
                .Where(schedule => schedule.OpTgID == operatorId)
                .Join(_context.TrRoute, schedule => schedule.RouteID, route => route.ID, (schedule, route) => new { schedule, route })
                .Join(_context.TramOperator, result => result.schedule.OpTgID, tramOperator => tramOperator.OpTgID, (result, tramOperator) => new MScheduleWithRouteAndOperator
                {
                    ID = result.schedule.ID,
                    TramID = result.schedule.TramID,
                    Weekdays = result.schedule.Weekdays,
                    DepartureTime = result.schedule.DepartureTime,
                    RouteName = result.route.Name,
                    RoutLength = result.route.RoutLength,
                    Duration = result.route.Duration,
                    Stops = _context.Stop
                        .Where(stop => stop.RouteID == result.schedule.RouteID)
                        .Select(stop => new MStop
                        {
                            ID = stop.ID,
                            Name = stop.Name,
                            RouteID = stop.RouteID,
                            Time = stop.Time,   
                        })
                        .ToList()
                })
                .ToListAsync();

            return scheduleWithStopsByOperator;
        }
    }
}
