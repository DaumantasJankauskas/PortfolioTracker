using Microsoft.AspNetCore.Authorization;
using PortfolioTracker.Auth.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioTracker.Auth
{
    public class SameUserAuthorizationHandler : AuthorizationHandler<SameUserRequirement, IUserOwnedResources>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SameUserRequirement requirement, IUserOwnedResources resource)
        {
            if (context.User.IsInRole(PortfolioUserRoles.Admin) || context.User.FindFirst(CustomClaims.UserId).Value == resource.UserId)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }

    public record SameUserRequirement : IAuthorizationRequirement;
}
