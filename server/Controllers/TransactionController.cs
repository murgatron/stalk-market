using System;
using System.Collections.Generic;
using Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Transaction;

namespace server.Controllers
{

    // TODO: to think about -- import csv of transactions for historical data? 
    [ApiController]
    [Route("api/v1/transactions")]
    public class TransactionController : ControllerBase
    {
        private readonly ILogger<TransactionController> _logger;

        public TransactionController(ILogger<TransactionController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Transaction>> Get()
        {
            _logger.LogInformation("Get Transactions");
            var transactions = new List<Transaction> {
                new Transaction {
                    Id = Guid.NewGuid(),
                    Price = 211,
                    Type = TransactionType.Sell,
                    OnIsland = Guid.NewGuid(),
                    Villager = Guid.NewGuid(),
                    Timestamp = new DateTime()
                }
             };
            return Ok(transactions);
        }
    }
}
