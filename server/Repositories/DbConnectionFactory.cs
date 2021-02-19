using System.Data;
using Npgsql;
using Repositories.Interfaces;

namespace Repositories
{
  public class DbConnectionFactory : IDbConnectionFactory
  {
    public IDbConnection GetConnection()
    {
      return new NpgsqlConnection(DbConfiguration.PG_CONNECTION);
    }
  }
}