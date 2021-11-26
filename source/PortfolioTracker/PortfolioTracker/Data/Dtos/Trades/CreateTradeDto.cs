using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioTracker.Data.Dtos.Trades
{
    public record CreateTradeDto(
        [Required]
        string Name,
        [Range(0, int.MaxValue, ErrorMessage = "The value must be greater than -1")]
        int Quantity,
        [Required]
        int AssetId,
        [Range(0, float.MaxValue, ErrorMessage = "The value must be greater than -1")]
        float AveragePrice,
        DateTime ExecutionDate,
        [Required]
        int PortfolioId
        );
}
