using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PortfolioTracker.Data.Dtos.Trades;
using PortfolioTracker.Data.Entities;
using PortfolioTracker.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioTracker.Controllers
{
    [ApiController]
    [Route("api/portfolios/{portfolioId}/trades")]
    public class TradesController : ControllerBase
    {
        private readonly ITradeRepository _tradesRepository;
        private readonly IMapper _mapper;
        private readonly IPortfolioRepository _portfoliosRepository;

        public TradesController(ITradeRepository tradesRepository, IMapper mapper, IPortfolioRepository portfoliosRepository)
        {
            _tradesRepository = tradesRepository;
            _mapper = mapper;
            _portfoliosRepository = portfoliosRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<TradeDto>> GetAllAsync(int portfolioId)
        {
            var portfolios = await _tradesRepository.GetAsync(portfolioId);
            return portfolios.Select(p => _mapper.Map<TradeDto>(p));
        }

        // /api/portfolios/1/trades/2
        [HttpGet("{tradeId}")]
        public async Task<ActionResult<TradeDto>> GetAsync(int portfolioId, int tradeId)
        {
            var trade = await _tradesRepository.GetAsync(portfolioId, tradeId);
            if (trade == null) return NotFound();

            return Ok(_mapper.Map<TradeDto>(trade));
        }

        [HttpPost]
        public async Task<ActionResult<TradeDto>> PostAsync(int portfolioId, CreateTradeDto tradeDto)
        {
            var portfolio = await _portfoliosRepository.GetAsync(portfolioId);
            if (portfolio == null) return NotFound($"Couldn't find a portfolio with id of {portfolioId}");

            var trade = _mapper.Map<Trade>(tradeDto);
            trade.PortfolioId = portfolioId;

            await _tradesRepository.CreateAsync(trade);

            return Created($"/api/portfolios/{portfolioId}/trades/{trade.Id}", _mapper.Map<TradeDto>(trade));
        }

        [HttpPut("{tradesId}")]
        public async Task<ActionResult<TradeDto>> PostAsync(int portfolioId, int tradeId, UpdateTradeDto tradeDto)
        {
            var portfolio = await _portfoliosRepository.GetAsync(portfolioId);
            if (portfolio == null) return NotFound($"Couldn't find a topic with id of {portfolioId}");

            var oldTrade = await _tradesRepository.GetAsync(portfolioId, tradeId);
            if (oldTrade == null)
                return NotFound();

            //oldPost.Body = postDto.Body;
            _mapper.Map(tradeDto, oldTrade);

            await _tradesRepository.UpdateAsync(oldTrade);

            return Ok(_mapper.Map<TradeDto>(oldTrade));
        }

        [HttpDelete("{tradeId}")]
        public async Task<ActionResult> DeleteAsync(int portfolioId, int tradeId)
        {
            var trade = await _tradesRepository.GetAsync(portfolioId, tradeId);
            if (trade == null)
                return NotFound();

            await _tradesRepository.DeleteAsync(trade);

            // 204
            return NoContent();
        }
    }
}
