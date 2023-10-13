using Microsoft.AspNetCore.Authorization;

namespace Jookli.Api.Modules.Configuration.Authorization
{
    public abstract class AttributeAuthorizationHandler<TRequirement, TAttribute>
        : AuthorizationHandler<TRequirement>
        where TRequirement : IAuthorizationRequirement
        where TAttribute : Attribute
    {
        

        protected abstract Task HandleRequirementAsync(
                 AuthorizationHandlerContext context,
                 TRequirement requirement,
                 TAttribute attribute);

    }
}
