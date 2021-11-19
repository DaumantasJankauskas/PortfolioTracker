using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioTracker.Data.Entities
{
    public class Asset
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public float CurrentPrice { get; set; }
        public float AskPrice { get; set; }
        public float BidPrice { get; set; }
        // public DateTime BoughtDateUtc { get; set; }
        public AssetCategory Category { get; set; }
    }
}
