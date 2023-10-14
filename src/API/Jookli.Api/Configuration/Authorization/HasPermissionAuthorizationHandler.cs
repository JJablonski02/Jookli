using Jookli.BuildingBlocks.Application;
using Jookli.UserAccess.Application.Authorization.GetUserPermissions;
using Jookli.UserAccess.Application.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace Jookli.Api.Configuration.Authorization
{
    internal class HasPermissionAuthorizationHandler : AttributeAuthorizationHandler<HasPermissionAuthorizationRequirement, HasPermissionAttribute>
    {
        private readonly IExecutionContextAccessor _executionContextAccessor;
        private readonly IUserAccessModule _userAccessModule;

        public HasPermissionAuthorizationHandler(IExecutionContextAccessor executionContextAccessor, IUserAccessModule userAccessModule)
        {
            _executionContextAccessor = executionContextAccessor;
            _userAccessModule = userAccessModule;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, HasPermissionAuthorizationRequirement requirement, HasPermissionAttribute attribute)
        {
            var permissions = await _userAccessModule.ExecuteQueryAsync(new GetUserPermissionsQuery(_executionContextAccessor.UserId));

            if(!await AuthorizeAsync(attribute.Name, permissions))
            {
                context.Fail();
                return;
            }
        }

        private Task<bool> AuthorizeAsync(string permission, List<UserPermissionsDTO> permissions)
        {
#if !DEBUG
            return Task.FromResult(true);
#endif
            return Task.FromResult(permissions.Any(x => x.Code== permission));
        }
    }
}
