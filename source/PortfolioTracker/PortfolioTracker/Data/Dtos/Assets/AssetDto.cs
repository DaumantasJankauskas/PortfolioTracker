using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioTracker.Data.Dtos.Assets
{
    public record AssetDto(
        int Id,
        string Name,
        string Description,
        int Quantity,
        float CurrentPrice,
        float AskPrice,
        float BidPrice,
        AssetCategory Category
        );
}
