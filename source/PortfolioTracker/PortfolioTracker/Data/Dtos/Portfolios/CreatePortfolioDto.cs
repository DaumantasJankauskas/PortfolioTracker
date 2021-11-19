using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioTracker.Data.Dtos.Portfolios
{
    public record CreatePortfolioDto([Required] string Title, string Description);
}
