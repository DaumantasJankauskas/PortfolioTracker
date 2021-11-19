using AutoMapper;
using PortfolioTracker.Data.Dtos.Portfolios;
using PortfolioTracker.Data.Dtos.Assets;
using PortfolioTracker.Data.Dtos.Trades;
using PortfolioTracker.Data.Entities;

namespace PortfolioTracker.Data
{
    public class PortfolioTrackerProfile : Profile
    {
        public PortfolioTrackerProfile()
        {
            CreateMap<CreateAssetDto, Asset>();
            CreateMap<UpdateAssetDto, Asset>();
            CreateMap<Asset, AssetDto>();

            CreateMap<CreatePortfolioDto, Portfolio>();
            CreateMap<UpdatePortfolioDto, Portfolio>();
            CreateMap<Portfolio, PortfolioDto>();

            CreateMap<CreatePortfolioDto, Trade>();
            CreateMap<UpdatePortfolioDto, Trade>();
            CreateMap<Trade, TradeDto>();
        }
    }
}
