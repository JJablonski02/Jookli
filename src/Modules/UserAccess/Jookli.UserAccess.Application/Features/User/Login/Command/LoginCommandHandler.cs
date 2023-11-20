using Dapper;
using Jookli.BuildingBlocks.Application.Data;
using Jookli.UserAccess.Application.Configuration.Command;
using Jookli.UserAccess.Domain.Entities.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.UserAccess.Application.Features.User.Login.Command
{
    public class LoginCommandHandler : ICommandHandler<LoginCommand>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public LoginCommandHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public Task<Unit> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();
            //in progress
            //dapper
            //validation
            //result
            return null;
        }
    }
}
