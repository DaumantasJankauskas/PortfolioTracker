using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioTracker.Data.Dtos.Trades
{
    public record TradeDto([Required] string Name, [Required] int AssetId, [Required] int Quantity,
        [Required] float AveragePrice, [Required] DateTime ExecutionDate, [Required] TradeType Type, [Required] int PortfolioId);

}
