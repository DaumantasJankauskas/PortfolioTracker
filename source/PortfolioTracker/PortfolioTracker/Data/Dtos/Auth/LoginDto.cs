using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioTracker.Data.Dtos.Auth
{
    public record LoginDto([Required] string UserName, [Required] string Password);
}