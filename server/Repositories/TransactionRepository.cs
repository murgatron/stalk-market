using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using Microsoft.Extensions.Logging;
using Models.CreateTransaction;
using Models.Transaction;

using Repositories.Interfaces;

namespace Repositories
{
  public class TransactionRepository : ITransactionRepository
  {
    private readonly ILogger<TransactionRepository> _logger;

    private readonly IDbConnectionFactory _connectionFactory;

    private readonly string TABLE_NAME = "\"stalkmarket\".\"stalk_transaction\"";

    public TransactionRepository(
        ILogger<TransactionRepository> logger,
        IDbConnectionFactory dbConnectionFactory
    )
    {
      _logger = logger;
      _connectionFactory = dbConnectionFactory;
    }

    public IEnumerable<Transaction> GetTransactions()
    {
      string sql = $"select id, price, type, on_island as onIsland, villager_id as villagerId, quantity, timestamp from {TABLE_NAME} limit (10)";

      using (var connection = _connectionFactory.GetConnection())
      {
        return connection.Query<Transaction>(sql).ToList();
      }
    }

    public IEnumerable<Transaction> CreateTransaction(CreateTransaction createTransaction)
    {
      string sql = new StringBuilder()
      .Append($"insert into {TABLE_NAME} (price, type, on_island, villager_id, quantity, timestamp) ")
      .Append("values (@Price, @Type, @OnIsland, @VillagerId, @Quantity, @Timestamp) ")
      .Append("returning (id, name, type, on_island as onIsland, villager_id as villagerId, quantity, timestamp);").ToString();

      using (var connection = _connectionFactory.GetConnection())
      {
        return connection.Query<Transaction>(sql, createTransaction);
      }
    }

    public void DeleteTransaction(Guid transactionId)
    {
      string sql = $"delete from {TABLE_NAME} where id = @Id;";

      using (var connection = _connectionFactory.GetConnection())
      {
        _logger.LogInformation($"Deleting transaction with id {transactionId}");
        connection.Execute(sql, transactionId);
      }
    }

  }
}