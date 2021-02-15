using System;
using System.Collections.Generic;
using Models.CreateTransaction;
using Models.Transaction;

namespace Repositories.Interfaces
{
    // No Updates. Only Create/Delete. 
    public interface ITransactionRepository
    {
        IEnumerable<Transaction> GetTransactions();
        IEnumerable<Transaction> CreateTransaction(CreateTransaction createTransaction);
        void DeleteTransaction(Guid transactionId);
    }
}