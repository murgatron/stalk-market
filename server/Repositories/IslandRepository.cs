using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using Microsoft.Extensions.Logging;
using Models.CreateIsland;
using Models.Island;
using Npgsql;
using Repositories.Interfaces.IIslandRepository;

namespace Repositories.IslandRepository
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
                var islands = connection.Query<Island>(sql).ToList();

                return islands;
            }
        }

        public IEnumerable<Island> CreateIsland(CreateIsland createIsland)
        {
            string sql = new StringBuilder()
            .Append($"insert into {TABLE_NAME} (id, name, owner_id, hemisphere, region, purchase_tax) ")
            .Append($"values (@Id, @Name, @OwnerId, @Hemisphere, @Region, @PurchaseTax) ")
            .Append("returning (id, name, owner_id, hemisphere, region, purchase_tax);").ToString();

            using (var connection = new NpgsqlConnection(DbConfiguration.PG_CONNECTION))
            {
                _logger.LogInformation($"Creating island with name {createIsland.Name}");
                var createdIsland = connection.Query<Island>(sql, createIsland);
                return createdIsland;
            }
        }

        public IEnumerable<Island> UpdateIsland(Guid islandId, CreateIsland updatePayload)
        {
            string sql = new StringBuilder().Append($"update {TABLE_NAME} ")
                .Append("set name = @Name, owner_id = @OwnerId, hemisphere = @Hemisphere, region = @Region, purchase_tax = @PurchaseTax")
                .Append("where id = @Id ")
                .Append("returning (id, name, owner_id, hemisphere, region, purchase_tax);")
                .ToString();

            using (var connection = new NpgsqlConnection(DbConfiguration.PG_CONNECTION))
            {
                _logger.LogInformation($"Updating island with id {islandId}");
                var updatedIsland = connection.Query<Island>(sql, updatePayload);
                return updatedIsland;
            }
        }

        public void DeleteIsland(Guid islandId)
        {
            // TODO
        }
    }
}