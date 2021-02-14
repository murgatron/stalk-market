using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Interfaces.IVillagerRepository;
using Models.Villager;

namespace Repositories.BasicRepository
{
    public class VillagerRepository : IVillagerRepository
    {
        // TODO: common config point for this thing
        private readonly string PGCONN = "User ID=tomnook;Password=tom-nook-stalks;Host=localhost;Port=5432;Database=nse;";

        public IEnumerable<Villager> GetVillagers()
        {
            string sql = "SELECT TOP 10 * FROM villager";

            using (var connection = new SqlConnection(PGCONN))
            {
                var villagers = connection.Query<Villager>(sql).ToList();

                Console.WriteLine(villagers.Count);

                return villagers;
            }
        }

    }
}