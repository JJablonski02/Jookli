using Dapper;
using Jookli.BuildingBlocks.Application.Data;
using Jookli.UserAccess.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Application.Common
{
    public class UsersCounter : IUsersCounter
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        public UsersCounter(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }
        public int CountUsersWithLogin(string login)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();

            const string sql = "SELECT COUNT(*) " +
                               "FROM [users].[v_Users] AS [User]" +
                               "WHERE [User].[Login] = @Login";
            return connection.QuerySingle<int>(sql,
                new
                {
                    login
                });
        }
    }
}
