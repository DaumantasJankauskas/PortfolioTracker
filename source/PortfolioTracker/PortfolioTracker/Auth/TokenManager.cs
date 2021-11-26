
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PortfolioTracker.Auth.Model;
using PortfolioTracker.Data.Dtos.Auth;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioTracker.Auth
{

    public interface ITokenManager
    {
        Task<string> CreateAccessTokenAsync(PortfolioUser portfolioUser);
    }
    public class TokenManager : ITokenManager
    {
        private readonly SymmetricSecurityKey _authSignInKey;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly UserManager<PortfolioUser> _userManager;

        public TokenManager(IConfiguration configuration, UserManager<PortfolioUser> userManager)
        {
            _authSignInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));
            _issuer = configuration["JWT:ValidIssuer"];
            _audience = configuration["JWT:ValidAudience"];
            _userManager = userManager;
        }

        public async Task<string> CreateAccessTokenAsync(PortfolioUser portfolioUser)
        {
            var userRoles = await _userManager.GetRolesAsync(portfolioUser);
            var authClaims = new List<Claim>
            {
                new Claim (ClaimTypes.Name , portfolioUser.UserName),
                new Claim (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim (CustomClaims.UserId, portfolioUser.Id.ToString()),
            };

            authClaims.AddRange(userRoles.Select(userRole => new Claim(ClaimTypes.Role, userRole)));

            var accessSecurityToken = new JwtSecurityToken(
                expires: DateTime.UtcNow.AddHours(1),
                issuer: _issuer.ToString(),
                audience: _audience.ToString(),
                claims: authClaims,
                signingCredentials: new SigningCredentials(_authSignInKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(accessSecurityToken);
        }
    }
}
