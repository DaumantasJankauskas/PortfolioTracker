using Microsoft.AspNetCore.Identity;
using PortfolioTracker.Auth.Model;
using PortfolioTracker.Data.Dtos.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioTracker.Data
{
    public class DatabaseSeeder
    {
        private readonly UserManager<PortfolioUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DatabaseSeeder(UserManager<PortfolioUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedAsync()
        {
            foreach ( var role in PortfolioUserRoles.All)
            {
                var roleExist = await _roleManager.RoleExistsAsync(role);
                if (!roleExist)
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            var newAdminUser = new PortfolioUser
            {
                UserName = "admin",
                Email = "admin@admin.com"
            };
            var existingAdminUser = await _userManager.FindByNameAsync(newAdminUser.UserName);
            if (existingAdminUser == null)
            {
                var createdAdminUserResult = await _userManager.CreateAsync(newAdminUser, "VerifySafePassword!");
                if (createdAdminUserResult.Succeeded)
                {
                    await _userManager.AddToRolesAsync(newAdminUser, PortfolioUserRoles.All);
                }
            }
        }
    }
}
