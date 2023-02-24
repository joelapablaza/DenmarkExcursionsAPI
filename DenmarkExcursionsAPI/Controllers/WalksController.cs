﻿using AutoMapper;
using DenmarkExcursionsAPI.Models.DTO;
using DenmarkExcursionsAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DenmarkExcursionsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalksController : Controller
    {
        private readonly IWalkRepository _walkRepository;
        private readonly IMapper _mapper;

        public WalksController(IWalkRepository walkRepository, IMapper mapper)
        {
            _walkRepository = walkRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWalksAsync()
        {
            var walks = await _walkRepository.GetAllAsync();

            //var walksDTO = new List<Models.DTO.Walk>();
            //walks.ToList().ForEach(walk =>
            //{
            //    var walkDTO = new Models.DTO.Walk()
            //    {
            //        Id = walk.Id,
            //        Name = walk.Name,
            //        Length = walk.Length,
            //        RegionId = walk.RegionId,
            //        WalkDifficultyId = walk.WalkDifficultyId,
            //    };
            //    walksDTO.Add(walkDTO);
            //});

            var walksDTO = _mapper.Map<List<Models.DTO.Walk>>(walks);

            return Ok(walksDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetWalkAsync")]
        public async Task<IActionResult> GetWalkAsync(Guid id)
        {
            // Get de Walk with the id
            var walk = await _walkRepository.GetAsync(id);
            // If null then NotFound
            if (walk == null)
            {
                return NotFound();
            }
            // Convert Domain to DTO
            //var walkDTO = new Models.DTO.Walk()
            //{
            //    Id = walk.Id,
            //    Name = walk.Name,
            //    Length = walk.Length,
            //    RegionId = walk.RegionId,
            //    WalkDifficultyId = walk.WalkDifficultyId,
            //};
            var walkDTO = _mapper.Map<Models.DTO.Walk>(walk);
            // Return Ok DTO
            return Ok(walkDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddWalkAsync([FromBody] AddWalkRequest addWalkRequest)
        {
            // ConvertDTO to Doman Object
            var walk = new Models.Domain.Walk()
            {
                Length = addWalkRequest.Length,
                Name = addWalkRequest.Name,
                RegionId = addWalkRequest.RegionId,
                WalkDifficultyId = addWalkRequest.WalkDifficultyId,
            };
            // Pass domain object to repository to persist
            walk = await _walkRepository.AddAsync(walk);
            // convert domain object to DTO
            var walkDTO = new Models.DTO.Walk()
            {
                Id = walk.Id,
                Length = walk.Length,
                Name = walk.Name,
                RegionId = walk.RegionId,
                WalkDifficultyId = walk.WalkDifficultyId,
            };
            // Send DTO response
            return CreatedAtAction(nameof(GetWalkAsync), new { id = walkDTO.Id }, walkDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateWalkAsync([FromRoute] Guid id, [FromBody] UpdateWalkRequest updateWalkRequest)
        {
            // Convert DTO to Doman object
            var walk = new Models.Domain.Walk()
            {
                Length = updateWalkRequest.Length,
                Name = updateWalkRequest.Name,
                RegionId = updateWalkRequest.RegionId,
                WalkDifficultyId = updateWalkRequest.WalkDifficultyId,
            };
            // Pass details to Repository
            walk = await _walkRepository.UpdateAsync(id, walk);
            // If null NotFound
            if (walk == null)
            {
                return NotFound();
            }
            // Convert Domain to DTO
            var walkDTO = new Models.DTO.Walk()
            {
                Id = walk.Id,
                Length = walk.Length,
                Name = walk.Name,
                RegionId = walk.RegionId,
                WalkDifficultyId = walk.WalkDifficultyId,
            };
            // Return response
            return Ok(walkDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteWalkAsync(Guid id)
        {
            var walk = await _walkRepository.DeleteAsync(id);

            if (walk == null)
            {
                return NotFound();
            }

            var walkDTO = new Models.DTO.Walk()
            {
                Id = walk.Id,
                Name = walk.Name,
                Length = walk.Length,
                RegionId = walk.RegionId,
                WalkDifficultyId = walk.WalkDifficultyId,
            };

            return Ok(walkDTO);
        }

    }
}