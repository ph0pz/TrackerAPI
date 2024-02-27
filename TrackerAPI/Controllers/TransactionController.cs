using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using TrackerAPI.Services.Interfaces;
using TrackerData;

namespace TrackerAPI.Controllers
{
    [Route("api/Transaction")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly TransactionInterface _transactionService;

        public TransactionController(TransactionInterface transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet("GetAllTransactionByMonth")]
        public async Task<ActionResult<List<object>>> GetAllTransactionByMonth(int userId, int month, int year)
        {
            var transactions = await _transactionService.GetAllTransactionByMonth(userId, month, year);
            return Ok(transactions);
        }

        [HttpGet("GetDayTransactionByMonth")]
        public async Task<ActionResult<List<object>>> GetDayTransactionByMonth(int userId, int month, int year)
        {
            var transactions = await _transactionService.GetDayTransactionByMonth(userId, month, year);
            return Ok(transactions);
        }

        [HttpGet("GetTransaction/{transactionId}")]
        public async Task<ActionResult<Transaction>> GetTransaction(int transactionId)
        {
            var transaction = await _transactionService.GetTransaction(transactionId);

            if (transaction == null)
            {
                return NotFound("Transaction not found.");
            }

            return Ok(transaction);
        }
        [HttpGet("GetIncome")]
        public async Task<ActionResult<Transaction>> GetIncome(int userId, int month, int year)
        {
            var transaction = await _transactionService.GetIncome(userId, month, year);

            if (transaction == null)
            {
                return NotFound("Transaction not found.");
            }

            return Ok(transaction);
        }

        [HttpPost("AddTransaction")]
        public async Task<ActionResult<Transaction>> AddTransaction([FromBody] Transaction transaction)
        {
            var addedTransaction = await _transactionService.AddTransaction(transaction);

            if (addedTransaction == null)
            {
                return BadRequest("Failed to add transaction.");
            }

            return Ok(addedTransaction);
        }

        [HttpPut("EditTransaction")]
        public async Task<ActionResult<Transaction>> EditTransaction([FromBody] Transaction transaction)
        {
            var editedTransaction = await _transactionService.EditTransaction(transaction);

            if (editedTransaction == null)
            {
                return NotFound("Transaction not found.");
            }

            return Ok(editedTransaction);
        }

        [HttpDelete("DeleteTransaction/{transactionId}")]
        public async Task<ActionResult> DeleteTransaction(int transactionId)
        {
            await _transactionService.DeleteTransaction(transactionId);
            return Ok("Transaction deleted successfully.");
        }
    }
}
