using Microsoft.AspNetCore.Mvc;
using ModernTramApi.Clients;
using ModernTramApi.Models;

namespace ModernTramApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : Controller
    {
        private readonly TicketClient _ticketService;

        public TicketController(TicketClient ticketService)
        {
            _ticketService = ticketService;
        }

        // GET: api/Ticket/GetAllTicketsForPessengare/{id}
        [HttpGet("GetAllTicketsForPessengare/{id}")]
        public async Task<IEnumerable<MTickets>> GetTicketsForPessengare(int id)
        {
            var tickets = await _ticketService.GetAllTicketsForPessengare(id);
            return tickets;
        }

        // GET: api/Ticket/GetAllTickets
        [HttpGet("GetAllTickets")]
        public async Task<IEnumerable<MTickets>> GetTickets()
        {
            var tickets = await _ticketService.GetAllTickets();
            return tickets;
        }

        // Post:api/Ticket/PostTicket
        [HttpPost("PostTicket")]
        public async Task<IActionResult> AddTicket([FromBody] MTickets ticket)
        {
            if (ticket == null)
            {
                return BadRequest("Invalid ticket data");
            }
            await _ticketService.AddTicketAsync(ticket);
            return Ok("Ticket added successfully");
        }
        // Post:api/Ticket/Delete/{id}
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> RemoveUser(int id)
        {
            var ticketToRemove = await _ticketService.GetTicketByIdAsync(id);

            if (ticketToRemove == null)
            {
                return NotFound("Ticket not found");
            }

            await _ticketService.RemoveTicketAsync(ticketToRemove);

            return Ok("Ticket removed successfully");
        }

        // GET: api/Ticket/HasValidTicket/{id}
        [HttpGet("HasValidTicket/{id}")]
        public async Task<IActionResult> HasValidTicket(int id)
        {
            var passengerTickets = await _ticketService.GetAllTicketsForPessengare(id);

            bool hasValidTicket = passengerTickets.Any(ticket =>
                ticket.PurchaseDateTime <= DateTime.Now && DateTime.Now <= ticket.ExpiryDateTime);

            return Ok(hasValidTicket);
        }


    }
}
