using Microsoft.EntityFrameworkCore;
using PortfolioTracker.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioTracker.Data.Repositories
{
    public interface ITradeRepository
    {
        Task<Trade> GetAsync(int portfolioId, int tradeId);
        Task<List<Trade>> GetAsync(int portfolioId);
        Task CreateAsync(Trade trade);
        Task UpdateAsync(Trade trade);
        Task DeleteAsync(Trade trade);
    }

    public class TradeRepository : ITradeRepository
    {
        private readonly PortfolioTrackerContext _portfolioTrackerContext;

        public TradeRepository(PortfolioTrackerContext portfolioTrackerContext)
        {
            _portfolioTrackerContext = portfolioTrackerContext;
        }

        public async Task<Trade> GetAsync(int portfolioId, int tradeId)
        {
            return await _portfolioTrackerContext.Trade.FirstOrDefaultAsync(trade => trade.PortfolioId == portfolioId && trade.Id == tradeId);
        }

        public async Task<List<Trade>> GetAsync(int portfolioId)
        {
            return await _portfolioTrackerContext.Trade.Where(trade => trade.PortfolioId == portfolioId).ToListAsync();
        }

        public async Task CreateAsync(Trade trade)
        {
            _portfolioTrackerContext.Trade.Add(trade);
            await _portfolioTrackerContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Trade trade)
        {
            _portfolioTrackerContext.Trade.Update(trade);
            await _portfolioTrackerContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Trade trade)
        {
            _portfolioTrackerContext.Trade.Remove(trade);
            await _portfolioTrackerContext.SaveChangesAsync();
        }
    }
}
