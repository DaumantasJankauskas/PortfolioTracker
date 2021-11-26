using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioTracker.Data.Dtos.Portfolios
{
    public record CreatePortfolioDto(
        [Required] string Title,
        string Description,
        [Range(0, float.MaxValue, ErrorMessage = "The value must be greater than 0")]
        float Value,
        DateTime CreationTimeUtc,
        [Required] string UserId
        );
}
