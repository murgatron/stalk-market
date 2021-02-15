using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Transaction;
using Models.CreateTransaction;
using Repositories.Interfaces;

namespace server.Controllers
{

    // TODO: to think about -- import csv of transactions for historical data? 
    [ApiController]
    [Route("api/v1/transactions")]
    public class TransactionController : ControllerBase
    {
        private readonly ILogger<TransactionController> _logger;

        private readonly ITransactionRepository _repository;

        public TransactionController(ILogger<TransactionController> logger, ITransactionRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        [Produces("application/json")]
        public ActionResult<IEnumerable<Transaction>> Get()
        {
            try
            {
                return Ok(_repository.GetTransactions());
            }
            catch (Exception e)
            {
                _logger.LogError("Exception occured trying to get transactions");
                return Problem(e.Message);
            }
        }

        [HttpPost]
        [Produces("application/json")]
        public ActionResult<IEnumerable<Transaction>> Create([FromBody] CreateTransaction createTransaction)
        {
            try
            {
                return Ok(_repository.CreateTransaction(createTransaction));
            }
            catch (Exception e)
            {
                _logger.LogError("Exception occured trying to create transaction");
                return Problem(e.Message);
            }
        }

        [HttpPatch("{transactionId}")]
        [Produces("application/json")]
        public ActionResult Delete(
            [FromRoute] Guid transactionId)
        {
            try
            {
                _repository.DeleteTransaction(transactionId);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError("Exception occured trying to delete transaction");
                return Problem(e.Message);
            }
        }
    }
}
