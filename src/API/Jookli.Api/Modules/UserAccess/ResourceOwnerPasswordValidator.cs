using IdentityServer4.Validation;
using Jookli.UserAccess.Application.Authentication.Authenticate;
using Jookli.UserAccess.Application.Contracts;

namespace Jookli.Api.Modules.UserAccess
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly IUserAccessModule _userAccessModule;

        public ResourceOwnerPasswordValidator(IUserAccessModule userAccessModule)
        {
            _userAccessModule = userAccessModule;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var authenticationResult = await _userAccessModule.ExecuteCommandAsync(
                new AuthenticateCommand(context.UserName, context.Password));

            if (!authenticationResult.IsAuthenticated)
            {
                context.Result = new GrantValidationResult(
                    IdentityServer4.Models.TokenRequestErrors.InvalidGrant,
                    authenticationResult.AuthenticationError);

                return;
            }
            context.Result = new GrantValidationResult(

                authenticationResult.User.Id.ToString(),
                "forms",
                authenticationResult.User.Claims
                );
        }
    }
}
