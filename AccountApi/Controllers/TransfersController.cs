using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AccountApi.Models;


namespace AccountApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransfersController : ControllerBase
    {
        private readonly AccountContext _context;

        public TransfersController(AccountContext context)
        {
            _context = context;
        }

        // GET: api/Transfers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transfer>>> GetTransferItems()
        {
            return await _context.TransferItems.ToListAsync();
        }

       
        // POST: api/Transfers
        [HttpPost]
        public async Task<ActionResult<Transfer>> PostTransfer(Transfer transfer)
        {
            var sourceAccount = await _context.AccountItems.SingleOrDefaultAsync(a => a.AccountNumber == transfer.SourceAccountNumber);
            var destinationAccount = await _context.AccountItems.SingleOrDefaultAsync(a => a.AccountNumber == transfer.DestinationAccountNumber);

            if (sourceAccount == null || destinationAccount == null)
            {
                return BadRequest("Source or destination account not found.");
            }

            sourceAccount.Insert(transfer.Amount);
            destinationAccount.Withdraw(transfer.Amount);

            _context.AccountItems.Update(sourceAccount);
            _context.AccountItems.Update(destinationAccount);


            //if (!transfer.ExecuteTransfer(sourceAccount))
            //{
            //    return BadRequest("Transfer failed due to insufficient balance or currency mismatch.");
            //}

            _context.TransferItems.Add(transfer);
            await _context.SaveChangesAsync();

            return Ok(transfer);
        }

    }
}
