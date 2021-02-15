using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Repositories.Interfaces.IVillagerRepository;
using Microsoft.Extensions.Logging;
using Models.Villager;
using Models.CreateVillager;
using Npgsql;

namespace Repositories.VillagerRepository
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
                var villagers = connection.Query<Villager>(sql).ToList();

                Console.WriteLine(villagers.Count);

                return villagers;
            }
        }

        public IEnumerable<Villager> CreateVillager(CreateVillager villagerToCreate)
        {

            string sql = $"insert into {TABLE_NAME} (id, name) values (@Id, @Name) returning (id, name);";

            using (var connection = new NpgsqlConnection(DbConfiguration.PG_CONNECTION))
            {
                _logger.LogInformation($"Creating villager with name {villagerToCreate.Name}");
                var createdVillager = connection.Query<Villager>(sql, villagerToCreate);
                return createdVillager;
            }
        }

        public IEnumerable<Villager> UpdateVillager(Guid villagerId, CreateVillager villagerToUpdate)
        {

            string sql = $"update {TABLE_NAME} set name = @Name where id = @Id returning (id, name);";

            using (var connection = new NpgsqlConnection(DbConfiguration.PG_CONNECTION))
            {
                _logger.LogInformation($"Updating villager with id {villagerId}");
                var updatedVillager = connection.Query<Villager>(sql, villagerToUpdate);
                return updatedVillager;
            }
        }

        public void DeleteVillager(Guid villagerId)
        {
            string sql = $"delete from {TABLE_NAME} where id = @Id;";

            using (var connection = new NpgsqlConnection(DbConfiguration.PG_CONNECTION))
            {
                Console.WriteLine($"Deleting villager with id {villagerId}");
                connection.Execute(sql, villagerId);
            }
        }

    }
}