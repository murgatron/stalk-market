using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using Microsoft.Extensions.Logging;
using Models.CreateStalk;
using Models.Stalk;
using Npgsql;
using Repositories.Interfaces;

namespace Repositories
{
  public class StalkRepository : IStalkRepository
  {
    private readonly ILogger<StalkRepository> _logger;
    private readonly IDbConnectionFactory _connectionFactory;

    private readonly string TABLE_NAME = "\"stalkmarket\".\"stalk\"";

    public StalkRepository(
        ILogger<StalkRepository> logger,
        IDbConnectionFactory dbConnectionFactory
    )
    {
      _logger = logger;
      _connectionFactory = dbConnectionFactory;
    }
    public IEnumerable<Stalk> GetStalks()
    {
      string sql = new StringBuilder().Append($"select ")
      .Append("id, island_id as islandId, meridian, shop_price as shopPrice, date, entered_by as enteredBy ")
      .Append($"from {TABLE_NAME} limit (10)").ToString();

      using (var connection = new NpgsqlConnection(DbConfiguration.PG_CONNECTION))
      {
        return connection.Query<Stalk>(sql).ToList();
      }
    }

    public IEnumerable<Stalk> CreateStalk(CreateStalk createStalk)
    {
      string sql = new StringBuilder()
      .Append($"insert into {TABLE_NAME} (island_id, meridian, shop_price, date, entered_by) ")
      .Append("values (@IslandId, @Meridian, @ShopPrice, @Date, @EnteredBy) ")
      .Append("returning (id, island_id, meridian, shop_price, date, entered_by);").ToString();

      using (var connection = _connectionFactory.GetConnection())
      {
        return connection.Query<Stalk>(sql, createStalk);
      }
    }

    public void DeleteStalk(Guid stalkId)
    {
      string sql = $"delete from {TABLE_NAME} where id = @Id;";

      using (var connection = _connectionFactory.GetConnection())
      {
        _logger.LogInformation($"Deleting stalk with id {stalkId}");
        connection.Execute(sql, stalkId);
      }
    }

  }
}