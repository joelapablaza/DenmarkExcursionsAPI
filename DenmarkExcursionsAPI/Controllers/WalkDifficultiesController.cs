using AutoMapper;
using DenmarkExcursionsAPI.Models.DTO;
using DenmarkExcursionsAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DenmarkExcursionsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalkDifficultiesController : Controller
    {
        private readonly IWalkDifficultyRepository _walkDifficultyRepository;
        private readonly IMapper _mapper;

        public WalkDifficultiesController(IWalkDifficultyRepository walkDifficultyRepository, IMapper mapper)
        {
            _walkDifficultyRepository = walkDifficultyRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWalkDifficulties()
        {
            var walkDifficulties = await _walkDifficultyRepository.GetAllAsync();

            var walkDifficultiesDTO = _mapper.Map<List<Models.DTO.WalkDifficulty>>(walkDifficulties);
            return Ok(walkDifficultiesDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetWalkDifficultyAsync")]
        public async Task<IActionResult> GetWalkDifficultyAsync(Guid id)
        {
            var walkDifficulty = await _walkDifficultyRepository.GetAsync(id);

            if (walkDifficulty == null)
            {
                return NotFound();
            }

            // Convert Domain to DTO
            var walkDifficultyDTO = _mapper.Map<Models.DTO.WalkDifficulty>(walkDifficulty);

            return Ok(walkDifficultyDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddWalkDifficultyAsync(AddWalkDifficultyRequest walkDifficultyRequest)
        {
            // Validation
            if (!ValidateAddWalkDifficultyAsync(walkDifficultyRequest))
            {
                return BadRequest(ModelState);
            }

            // Convert DTO to Doman model
            var walkDifficulty = new Models.Domain.WalkDifficulty()
            {
                Code = walkDifficultyRequest.Code,
            };

            // Call repository
            walkDifficulty = await _walkDifficultyRepository.AddAsync(walkDifficulty);

            // Convert to DTO
            var walkDifficultyDTO = _mapper.Map<Models.DTO.WalkDifficulty>(walkDifficulty);

            return CreatedAtAction(nameof(GetWalkDifficultyAsync),
                new { id = walkDifficultyDTO.Id }, walkDifficultyDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateWalkDifficultyAsync(Guid id, UpdateWalkDifficultyRequest updateWalkDifficultyRequest)
        {
            // Validate
            if(! (ValidateUpdateWalkDifficultyAsync(updateWalkDifficultyRequest)))
            {
                return BadRequest(ModelState);
            }

            // Convert DTO to Doman model
            var walkDifficulty = new Models.Domain.WalkDifficulty()
            {
                Code = updateWalkDifficultyRequest.Code,
            };

            // Call repository to update
            walkDifficulty = await _walkDifficultyRepository.UpdateAsync(id, walkDifficulty);
        
            if(walkDifficulty == null) { return NotFound(); }

            // Convert to DTO
            var walkDifficultyDTO = _mapper.Map<Models.DTO.WalkDifficulty>(walkDifficulty);

            // Return Ok Response
            return Ok(walkDifficultyDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteWalkDifficulty(Guid id)
        {
            var walkDifficulty = await _walkDifficultyRepository.DeleteAsync(id);

            if (walkDifficulty == null) { return NotFound(); }

            // Convert To DTO
            var walkDifficultyDTO = _mapper.Map<Models.DTO.WalkDifficulty>(walkDifficulty);

            return Ok(walkDifficultyDTO);
        }

        #region Private methods

        private bool ValidateAddWalkDifficultyAsync(AddWalkDifficultyRequest walkDifficultyRequest)
        {
            if (walkDifficultyRequest == null)
            {
                ModelState.AddModelError(nameof(walkDifficultyRequest),
                    $"{nameof(walkDifficultyRequest)} is required");
            }

            if (string.IsNullOrWhiteSpace(walkDifficultyRequest.Code))
            {
                ModelState.AddModelError(nameof(walkDifficultyRequest.Code),
                    $"{nameof(walkDifficultyRequest.Code)} is required");
            }

            if (ModelState.ErrorCount > 0)
            {
                return false;
            }

            return true;
        }

        private bool ValidateUpdateWalkDifficultyAsync(UpdateWalkDifficultyRequest updateDifficultyRequest)
        {
            if (updateDifficultyRequest == null)
            {
                ModelState.AddModelError(nameof(updateDifficultyRequest),
                    $"{nameof(updateDifficultyRequest)} is required");
            }

            if (string.IsNullOrWhiteSpace(updateDifficultyRequest.Code))
            {
                ModelState.AddModelError(nameof(updateDifficultyRequest.Code),
                    $"{nameof(updateDifficultyRequest.Code)} is required");
            }

            if (ModelState.ErrorCount > 0)
            {
                return false;
            }

            return true;
        }

        #endregion

    }
}
