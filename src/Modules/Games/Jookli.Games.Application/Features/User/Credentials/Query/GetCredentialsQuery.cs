using Jookli.Games.Application.Contracts;

namespace Jookli.Games.Application.Features.User.Credentials.Query
{
    public class GetCredentialsQuery : QueryBase<CredentialsDTO>
    {
        public GetCredentialsQuery(string token)
        {
            Token = token;
        }
        public string Token { get; set; }   
    }
}
