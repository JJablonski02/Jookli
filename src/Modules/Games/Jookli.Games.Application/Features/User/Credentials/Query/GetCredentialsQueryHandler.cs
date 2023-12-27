using Dapper;
using Jookli.BuildingBlocks.Application.Data;
using Jookli.Games.Application.Configuration.Query;
using Jookli.Games.Application.Features.User.Credentials.Query;
using Jookli.Games.Domain.Entities.User.Repository;

namespace Jookli.Games.Application.Features.User.Credentials.Command
{
    public class GetCredentialsQueryHandler : IQueryHandler<GetCredentialsQuery, CredentialsDTO>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        private readonly IUserRepository _userRepository;

        public GetCredentialsQueryHandler(ISqlConnectionFactory sqlConnectionFactory, IUserRepository userRepository)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
            _userRepository = userRepository;
        }
        public async Task<CredentialsDTO> Handle(GetCredentialsQuery command, CancellationToken cancellationToken)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();
            
            const string sql = "SELECT " +
                $"User.Email AS {nameof(CredentialsDTO.UserName)}, " +
                $"User.UserGamesId AS {nameof(CredentialsDTO.UniqueUserIdentifier)} " +
                $"FROM Games_User AS User";

            var result = await connection.QuerySingleOrDefaultAsync<CredentialsDTO>(sql, cancellationToken);

            return result;
        }
    }
}
