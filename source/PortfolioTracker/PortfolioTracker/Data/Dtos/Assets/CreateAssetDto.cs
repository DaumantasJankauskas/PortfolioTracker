using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioTracker.Data.Dtos.Assets
{
    public record CreateAssetDto([Required] int Id, [Required] string Name, string Description, [Required] int Quantity,
            float CurrentPrice, float AskPrice, float BidPrice, [Required] AssetCategory Category);
}
