using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.BuildingBlocks.Application.Data
{
    public interface ISqlConnectionFactory
    {
        IDbConnection GetDbConnection();
        IDbConnection CreateNewConnection();
        string GetConnectionString();
    }
}
