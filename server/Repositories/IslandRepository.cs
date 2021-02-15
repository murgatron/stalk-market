using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using Microsoft.Extensions.Logging;
using Models.CreateIsland;
using Models.Island;
using Npgsql;
using Repositories.Interfaces;

namespace Repositories
{
    public class IslandRepository : IIslandRepository
    {

        private readonly ILogger<IslandRepository> _logger;

        private readonly string TABLE_NAME = "\"stalkmarket\".\"island\"";

        public IslandRepository(ILogger<IslandRepository> logger)
        {
            _logger = logger;
        }

        public IEnumerable<Island> GetIslands()
        {
            string sql = $"select * from {TABLE_NAME} limit (10)";

            using (var connection = new NpgsqlConnection(DbConfiguration.PG_CONNECTION))
            {
                return connection.Query<Island>(sql).ToList();
            }
        }

        public IEnumerable<Island> CreateIsland(CreateIsland createIsland)
        {
            string sql = new StringBuilder()
            .Append($"insert into {TABLE_NAME} (name, owner_id, hemisphere, region, sales_tax) ")
            .Append($"values (@Name, @OwnerId, @Hemisphere, @Region, @SalesTax) ")
            .Append("returning (id, name, owner_id, hemisphere, region, sales_tax);").ToString();

            using (var connection = new NpgsqlConnection(DbConfiguration.PG_CONNECTION))
            {
                _logger.LogInformation($"Creating island with name {createIsland.Name}");
                return connection.Query<Island>(sql, createIsland);
            }
        }

        public IEnumerable<Island> UpdateIsland(Guid islandId, CreateIsland updatePayload)
        {
            string sql = new StringBuilder().Append($"update {TABLE_NAME} ")
                .Append("set name = @Name, owner_id = @OwnerId, hemisphere = @Hemisphere, region = @Region, sales_tax = @SalesTax")
                .Append("where id = @Id ")
                .Append("returning (id, name, owner_id, hemisphere, region, sales_tax);")
                .ToString();

            using (var connection = new NpgsqlConnection(DbConfiguration.PG_CONNECTION))
            {
                _logger.LogInformation($"Updating island with id {islandId}");
                return connection.Query<Island>(sql, updatePayload);
            }
        }

        public void DeleteIsland(Guid islandId)
        {
            string sql = $"delete from {TABLE_NAME} where id = @Id;";

            using (var connection = new NpgsqlConnection(DbConfiguration.PG_CONNECTION))
            {
                _logger.LogInformation($"Deleting island with id {islandId}");
                connection.Execute(sql, islandId);
            }
        }
    }
}