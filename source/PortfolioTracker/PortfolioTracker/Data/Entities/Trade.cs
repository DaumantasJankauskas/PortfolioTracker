using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioTracker.Data.Entities
{
    public class Trade
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Name { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Required")]
        public int AssetId { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "The value must be greater than 0")]
        public float AveragePrice { get; set; }

        public DateTime ExecutionDate { get; set; }

        [Required(ErrorMessage = "Required")]
        public int PortfolioId { get; set; }
    }
}
