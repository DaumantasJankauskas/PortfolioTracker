using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioTracker.Data.Dtos.Portfolios
{
    public record UpdatePortfolioDto(string Title, string Description, float Value, DateTime CreationTimeUtc);
}
