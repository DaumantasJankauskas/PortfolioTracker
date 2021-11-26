using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioTracker.Data.Dtos.Assets
{
    public record UpdateAssetDto(string Name, string Description, int Quantity, float CurrentPrice, AssetCategory Category);
}
