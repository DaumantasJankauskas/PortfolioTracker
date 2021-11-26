using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioTracker.Data.Dtos.Assets
{
    public record CreateAssetDto(
    [MaxLength(255), MinLength(1)]
    [Required(ErrorMessage = "Required")]
    string Name,

    string Description,

    [Range(0, int.MaxValue, ErrorMessage = "The value must be greater than 0")]
    int Quantity,

    [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
    float CurrentPrice,

    [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
    float AskPrice,
    [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
    float BidPrice,
    AssetCategory Category

    );
}
