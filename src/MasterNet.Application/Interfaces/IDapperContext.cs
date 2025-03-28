using System.Data;

namespace MasterNet.Application.Interfaces
{
    public interface IDapperContext
    {
        IDbConnection CreateConnection();
    }
}
