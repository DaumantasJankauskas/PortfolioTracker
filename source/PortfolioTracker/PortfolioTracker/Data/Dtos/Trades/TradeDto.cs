using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioTracker.Data.Dtos.Trades
{
    public record TradeDto(int Id, [Required] string Name, int Quantity, int AssetId, float AveragePrice, [Required] DateTime ExecutionDate, int PortfolioId);

}
