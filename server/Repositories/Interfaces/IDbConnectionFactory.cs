using System.Data;

namespace Repositories.Interfaces
{

  public interface IDbConnectionFactory
  {
    IDbConnection GetConnection();
  }

}