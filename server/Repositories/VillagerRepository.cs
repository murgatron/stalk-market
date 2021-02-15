using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Microsoft.Extensions.Logging;
using Models.CreateVillager;
using Models.Villager;
using Npgsql;
using Repositories.Interfaces;

namespace Repositories
{
    public class VillagerRepository : IVillagerRepository
    {
        private readonly ILogger<VillagerRepository> _logger;

        private readonly string TABLE_NAME = "\"stalkmarket\".\"villager\"";

        public VillagerRepository(ILogger<VillagerRepository> logger)
        {
            _logger = logger;
        }
        public IEnumerable<Villager> GetVillagers()
        {
            string sql = $"select * from {TABLE_NAME} limit (10)";

            using (var connection = new NpgsqlConnection(DbConfiguration.PG_CONNECTION))
            {
                return connection.Query<Villager>(sql).ToList();
            }
        }

        public IEnumerable<Villager> CreateVillager(CreateVillager villagerToCreate)
        {

            string sql = $"insert into {TABLE_NAME} (name) values (@Name) returning (id, name);";

            using (var connection = new NpgsqlConnection(DbConfiguration.PG_CONNECTION))
            {
                _logger.LogInformation($"Creating villager with name {villagerToCreate.Name}");
                return connection.Query<Villager>(sql, villagerToCreate);
            }
        }

        public IEnumerable<Villager> UpdateVillager(Guid villagerId, CreateVillager villagerToUpdate)
        {
            string sql = $"update {TABLE_NAME} set name = @Name where id = @Id returning (id, name);";

            using (var connection = new NpgsqlConnection(DbConfiguration.PG_CONNECTION))
            {
                _logger.LogInformation($"Updating villager with id {villagerId}");
                return connection.Query<Villager>(sql, villagerToUpdate);
            }
        }

        public void DeleteVillager(Guid villagerId)
        {
            string sql = $"delete from {TABLE_NAME} where id = @Id;";

            using (var connection = new NpgsqlConnection(DbConfiguration.PG_CONNECTION))
            {
                _logger.LogInformation($"Deleting villager with id {villagerId}");
                connection.Execute(sql, villagerId);
            }
        }

    }
}