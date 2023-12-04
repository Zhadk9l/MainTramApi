using Microsoft.EntityFrameworkCore;
using ModernTramApi.Db;
using ModernTramApi.Models;
using ModernTramApi.Db;

namespace ModernTramApi.Clients
{
    public class OperatorClient
    {
        private HttpClient _client;
        private readonly ApplicationDbContext _context;

        public OperatorClient(ApplicationDbContext context)
        {
            _context = context;
            _client = new HttpClient();
        }

        public async Task<string> IsOperatorAsync(int id)
        {
            var operat = await _context.TramOperator.FindAsync(id);
            if (operat == null) 
            {
                return "none";
            }
            return operat.OperatorPasswor;
        }
        public async Task<IEnumerable<MTramOperator>> GetAllOper()
        {
            var oper = await _context.TramOperator.ToListAsync();

            if (oper != null)
            {
                return oper;
            }
            else
            {
                return Enumerable.Empty<MTramOperator>();
            }
        }
        public async Task<MTramOperator> GetOperByIdAsync(int id)
        {
            return await _context.TramOperator.FindAsync(id);
        }
        public async Task AddOperAsync(MTramOperator oper)
        {
            await _context.AddTramOperatorAsync(oper);
        }
        public async Task RemoveOperAsync(MTramOperator oper)
        {
            await _context.RemoveTramOperatorAsync(oper);
        }
        public async Task UpdateOperAsync(MTramOperator oper)
        {
            var existingOper = await _context.TramOperator.FindAsync(oper.OpTgID);

            if (existingOper != null)
            {
                
                existingOper.Name = oper.Name;
                existingOper.TgName = oper.TgName;
                existingOper.OperatorPasswor = oper.OperatorPasswor;
                

                await _context.SaveChangesAsync();
            }
        }

    }
}
