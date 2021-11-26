using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioTracker.Data.Dtos.Trades
{
    public record UpdateTradeDto(string Name, int Quantity, int AssetId, float AveragePrice, DateTime ExecutionDate, int PortfolioId);
}
