using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            string sql = new StringBuilder()
            .Append($"insert into {TABLE_NAME} (price, type, on_island, villager_id, quantity, timestamp) ")
            .Append("values (@Price, @Type, @OnIsland, @VillagerId, @Quantity, @Timestamp) ")
            .Append("returning (id, name, type, on_island, villager_id, quantity, timestamp);").ToString();

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