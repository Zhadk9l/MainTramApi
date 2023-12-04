using Microsoft.AspNetCore.Mvc;
using ModernTramApi.Clients;
using ModernTramApi.Models;

namespace ModernTramApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperatorController : Controller
    {
        private readonly OperatorClient _operatorService;

        public OperatorController(OperatorClient operatorService)
        {
            _operatorService = operatorService;
        }


        // GET: api/Operator/GetAllOpeator
        [HttpGet("GetAllOpearator")]
        public async Task<IEnumerable<MTramOperator>> GetOperator()
        {
            var oper = await _operatorService.GetAllOper();
            return oper;
        }
        // GET: api/Operator/IsOper
        [HttpGet("IsOper/{id}")]
        public async Task<string> GetOper(int id)
        {
            string oper = await _operatorService.IsOperatorAsync(id);
            return oper;
        }

        // Post:api/Operator/PostOper
        [HttpPost("PostOper")]
        public async Task<IActionResult> AddOper([FromBody] MTramOperator oper)
        {
            if (oper == null)
            {
                return BadRequest("Invalid ticket data");
            }
            await _operatorService.AddOperAsync(oper);
            return Ok("Operator added successfully");
        }
        // Post:api/Staff/Delete/{id}
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> RemoveOper(int id)
        {
            var operToRemove = await _operatorService.GetOperByIdAsync(id);

            if (operToRemove == null)
            {
                return NotFound("Operator not found");
            }

            await _operatorService.RemoveOperAsync(operToRemove);

            return Ok("Operator removed successfully");
        }
        // Put:api/Staff/UpdateOper
        [HttpPut("UpdateOper")]
        public async Task<IActionResult> UpdateOper([FromBody] MTramOperator oper)
        {
            if (oper == null)
            {
                return BadRequest("Invalid operator data");
            }

            await _operatorService.UpdateOperAsync(oper);

            return Ok("Operator updated successfully");
        }

    }
}
