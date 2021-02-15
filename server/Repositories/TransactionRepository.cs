using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Microsoft.Extensions.Logging;
using Models.CreateTransaction;
using Models.Transaction;
using Npgsql;
using Repositories.Interfaces;

namespace Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ILogger<TransactionRepository> _logger;

        private readonly string TABLE_NAME = "\"stalkmarket\".\"stalk_transaction\"";

        public TransactionRepository(ILogger<TransactionRepository> logger)
        {
            _logger = logger;
        }

        public IEnumerable<Transaction> GetTransactions()
        {
            string sql = $"select * from {TABLE_NAME} limit (10)";

            using (var connection = new NpgsqlConnection(DbConfiguration.PG_CONNECTION))
            {
                return connection.Query<Transaction>(sql).ToList();
            }
        }

        public IEnumerable<Transaction> CreateTransaction(CreateTransaction createTransaction)
        {

            string sql = $"insert into {TABLE_NAME} (id, name) values (@Id, @Name) returning (id, name);";

            using (var connection = new NpgsqlConnection(DbConfiguration.PG_CONNECTION))
            {
                return connection.Query<Transaction>(sql, createTransaction);
            }
        }

        public void DeleteTransaction(Guid transactionId)
        {
            string sql = $"delete from {TABLE_NAME} where id = @Id;";

            using (var connection = new NpgsqlConnection(DbConfiguration.PG_CONNECTION))
            {
                _logger.LogInformation($"Deleting transaction with id {transactionId}");
                connection.Execute(sql, transactionId);
            }
        }

    }
}