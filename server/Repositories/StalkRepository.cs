using System;
using System.Collections.Generic;
using System.Linq;
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

        private readonly string TABLE_NAME = "\"stalkmarket\".\"stalk\"";

        public StalkRepository(ILogger<StalkRepository> logger)
        {
            _logger = logger;
        }
        public IEnumerable<Stalk> GetStalks()
        {
            string sql = $"select * from {TABLE_NAME} limit (10)";

            using (var connection = new NpgsqlConnection(DbConfiguration.PG_CONNECTION))
            {
                return connection.Query<Stalk>(sql).ToList();
            }
        }

        public IEnumerable<Stalk> CreateStalk(CreateStalk createStalk)
        {

            string sql = $"insert into {TABLE_NAME} (id, name) values (@Id, @Name) returning (id, name);";

            using (var connection = new NpgsqlConnection(DbConfiguration.PG_CONNECTION))
            {
                return connection.Query<Stalk>(sql, createStalk);
            }
        }

        public void DeleteStalk(Guid stalkId)
        {
            string sql = $"delete from {TABLE_NAME} where id = @Id;";

            using (var connection = new NpgsqlConnection(DbConfiguration.PG_CONNECTION))
            {
                _logger.LogInformation($"Deleting stalk with id {stalkId}");
                connection.Execute(sql, stalkId);
            }
        }

    }
}