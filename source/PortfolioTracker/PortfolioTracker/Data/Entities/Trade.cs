using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioTracker.Data.Entities
{
    public class Trade
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AssetId { get; set; }
        public Asset Asset { get; set; }
        public int Quantity { get; set; }
        public float AveragePrice { get; set; }
        public DateTime ExecutionDate { get; set; }
        public TradeType Type { get; set; }
        public int PortfolioId { get; set; }
        public Portfolio Portfolio { get; set; }
    }
}
