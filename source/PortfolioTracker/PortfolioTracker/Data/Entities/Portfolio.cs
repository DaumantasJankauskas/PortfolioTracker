using PortfolioTracker.Auth.Model;
using PortfolioTracker.Data.Dtos.Auth;
using PortfolioTracker.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioTracker.Data
{
    public class Portfolio : IUserOwnedResources
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public float Value { get; set; }
        public DateTime CreationTimeUtc { get; set; }

        public List<Asset> AssetsList { get; set; }
        public List<Trade> TradesList { get; set; }


        [Required]
        public string UserId { get; set; }
        public PortfolioUser User { get; set; }
    }
}
