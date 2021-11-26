using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PortfolioTracker.Data.Dtos.Portfolios;
using PortfolioTracker.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using PortfolioTracker.Data;
using Microsoft.AspNetCore.Authorization;
using PortfolioTracker.Data.Dtos.Auth;
using PortfolioTracker.Auth.Model;

namespace PortfolioTracker.Controllers
{
    [ApiController]
    [Route("api/portfolios/")]
    public class PortfolioController : ControllerBase
    {
        private readonly IPortfolioRepository _portfolioRepository;
        private readonly IMapper _mapper;
        private readonly IAuthorizationService _authorizationService;

        public PortfolioController(IPortfolioRepository portfolioRepository, IMapper mapper, IAuthorizationService authorizationService)
        {
            _portfolioRepository = portfolioRepository;
            _mapper = mapper;
            _authorizationService = authorizationService;
        }

        [HttpGet]
        [Authorize(Roles = PortfolioUserRoles.SimpleUser)]
        public async Task<IEnumerable<PortfolioDto>> GetAllAsync()
        {
            var userClaims = User;
            var portfolio = await _portfolioRepository.GetAsync();
            return portfolio.Select(portfolio => _mapper.Map<PortfolioDto>(portfolio));
        }

        [HttpGet("{portfolioId}")]
        [Authorize(Roles = PortfolioUserRoles.SimpleUser)]
        public async Task<ActionResult<PortfolioDto>> GetAsync(int portfolioId)
        {
            var portfolio = await _portfolioRepository.GetAsync(portfolioId);
            if (portfolio == null) return NotFound();

            return Ok(_mapper.Map<PortfolioDto>(portfolio));
        }

        [HttpPost]
        public async Task<ActionResult<PortfolioDto>> PostAsync(CreatePortfolioDto portfolioDto)
        {
            var portfolio = _mapper.Map<Portfolio>(portfolioDto);

            await _portfolioRepository.CreateAsync(portfolio);

            return Created($"/api/portfolios/{portfolio.Id}", _mapper.Map<PortfolioDto>(portfolio));
        }

        [HttpPut("{portfolioId}")]
        [Authorize(Roles = PortfolioUserRoles.SimpleUser)]
        public async Task<ActionResult<PortfolioDto>> PutAsync(int portfolioId, UpdatePortfolioDto portfolioDto)
        {
            var oldPortfolio = await _portfolioRepository.GetAsync(portfolioId);
            if (oldPortfolio == null)
                return NotFound();

            var authorizationResult = await _authorizationService.AuthorizeAsync(User, oldPortfolio, PolicyNames.SameUser);

            if (!authorizationResult.Succeeded)
                return Forbid();

            _mapper.Map(portfolioDto, oldPortfolio);

            await _portfolioRepository.UpdateAsync(oldPortfolio);

            return Ok(_mapper.Map<PortfolioDto>(oldPortfolio));
        }

        [HttpDelete("{portfolioId}")]
        [Authorize(Roles = PortfolioUserRoles.SimpleUser)]
        public async Task<ActionResult> DeleteAsync(int portfolioId)
        {
            var portfolio = await _portfolioRepository.GetAsync(portfolioId);
            if (portfolio == null)
                return NotFound();

            var authorizationResult = await _authorizationService.AuthorizeAsync(User, portfolio, PolicyNames.SameUser);

            if (!authorizationResult.Succeeded)
                return Forbid();

            await _portfolioRepository.DeleteAsync(portfolio);

            // 204
            return NoContent();
        }
    }
}
