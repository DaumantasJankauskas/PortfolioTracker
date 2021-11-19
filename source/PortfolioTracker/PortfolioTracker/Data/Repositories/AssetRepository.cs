using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PortfolioTracker.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace PortfolioTracker.Data.Repositories
{
    public interface IAssetRepository
    {
        Task<Asset> GetAsync(int assetId);
        Task<List<Asset>> GetAsync();
        Task CreateAsync(Asset asset);
        Task UpdateAsync(Asset asset);
        Task DeleteAsync(Asset asset);
    }

    public class AssetRepository : IAssetRepository
    {
        private readonly PortfolioTrackerContext _portfolioTrackerContext;

        public AssetRepository(PortfolioTrackerContext portfolioTrackerContext)
        {
            this._portfolioTrackerContext = portfolioTrackerContext;
        }

        public async Task<Asset> GetAsync(int assetId)
        {
            return await _portfolioTrackerContext.Asset.FirstOrDefaultAsync(asset => asset.Id == assetId);
        }

        public async Task<List<Asset>> GetAsync()
        {
            return await _portfolioTrackerContext.Asset.ToListAsync();
        }

        public async Task CreateAsync(Asset asset)
        {
            _portfolioTrackerContext.Asset.Add(asset);
            await _portfolioTrackerContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Asset asset)
        {
            _portfolioTrackerContext.Asset.Update(asset);
            await _portfolioTrackerContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Asset asset)
        {
            _portfolioTrackerContext.Asset.Remove(asset);
            await _portfolioTrackerContext.SaveChangesAsync();
        }
    }
}
