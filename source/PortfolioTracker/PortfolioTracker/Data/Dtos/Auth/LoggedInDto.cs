using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioTracker.Data.Dtos.Auth
{
    public record LoggedInDto(string AccesToken, List<string> roles, string username, string userid);
}