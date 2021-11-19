using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioTracker.Data.Dtos.Trades
{
    public record CreateTradeDto(string Name, int AssetId, int Quantity,
        float AveragePrice, DateTime ExecutionDate, TradeType Type, int PortfolioId);
}
