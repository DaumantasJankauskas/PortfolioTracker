using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PortfolioTracker.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace PortfolioTracker.Data.Repositories
{
    public interface IPortfolioRepository
    {
        Task<Portfolio> GetAsync(int portfolioId);
        Task<List<Portfolio>> GetAsync();
        Task CreateAsync(Portfolio portfolio);
        Task UpdateAsync(Portfolio portfolio);
        Task DeleteAsync(Portfolio portfolio);
    }

    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly PortfolioTrackerContext _portfolioTrackerContext;

        public PortfolioRepository(PortfolioTrackerContext portfolioTrackerContext)
        {
            this._portfolioTrackerContext = portfolioTrackerContext;
        }

        public async Task<Portfolio> GetAsync(int portfolioId)
        {
            return await _portfolioTrackerContext.Portfolio.FirstOrDefaultAsync(portfolio => portfolio.Id == portfolioId);
        }

        public async Task<List<Portfolio>> GetAsync()
        {
            return await _portfolioTrackerContext.Portfolio.ToListAsync();
        }

        public async Task CreateAsync(Portfolio portfolio)
        {
            _portfolioTrackerContext.Portfolio.Add(portfolio);
            await _portfolioTrackerContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Portfolio portfolio)
        {
            _portfolioTrackerContext.Portfolio.Update(portfolio);
            await _portfolioTrackerContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Portfolio portfolio)
        {
            _portfolioTrackerContext.Portfolio.Remove(portfolio);
            await _portfolioTrackerContext.SaveChangesAsync();
        }
    }
}
