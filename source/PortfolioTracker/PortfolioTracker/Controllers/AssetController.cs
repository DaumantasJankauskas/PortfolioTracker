using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PortfolioTracker.Data.Dtos.Assets;
using PortfolioTracker.Data.Entities;
using PortfolioTracker.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioTracker.Controllers
{
    [ApiController]
    [Route("api/assets/")]
    public class AssetsController : ControllerBase
    {
        private readonly IAssetRepository _assetsRepository;
        private readonly IMapper _mapper;

        public AssetsController(IAssetRepository assetsRepository, IMapper mapper)
        {
            _assetsRepository = assetsRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<AssetDto>> GetAllAsync()
        {
            var assets = await _assetsRepository.GetAsync();
            return assets.Select(asset => _mapper.Map<AssetDto>(asset));
        }

        [HttpGet("{assetId}")]
        public async Task<ActionResult<AssetDto>> GetAsync(int assetId)
        {
            var asset = await _assetsRepository.GetAsync(assetId);
            if (asset == null) return NotFound();

            return Ok(_mapper.Map<AssetDto>(asset));
        }

        [HttpPost]
        public async Task<ActionResult<AssetDto>> PostAsync(CreateAssetDto assetDto)
        {
            var asset = _mapper.Map<Asset>(assetDto);

            await _assetsRepository.CreateAsync(asset);

            return Created($"/api/assets/{asset.Id}", _mapper.Map<AssetDto>(asset));
        }

        [HttpPut("{assetId}")]
        public async Task<ActionResult<AssetDto>> PostAsync(int assetId, UpdateAssetDto assetDto)
        {
            var oldAsset = await _assetsRepository.GetAsync(assetId);
            if (oldAsset == null)
                return NotFound();

            //oldPost.Body = postDto.Body;
            _mapper.Map(assetDto, oldAsset);

            await _assetsRepository.UpdateAsync(oldAsset);

            return Ok(_mapper.Map<AssetDto>(oldAsset));
        }

        [HttpDelete("{assetId}")]
        public async Task<ActionResult> DeleteAsync(int assetId)
        {
            var asset = await _assetsRepository.GetAsync(assetId);
            if (asset == null)
                return NotFound();

            await _assetsRepository.DeleteAsync(asset);

            // 204
            return NoContent();
        }
    }
}
