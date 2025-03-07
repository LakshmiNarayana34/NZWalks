using System.Runtime.InteropServices;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWalkRepository _walkRepository;
        private readonly NZWalksDbContext _nZWalksDbContext;
        
        public WalksController(IMapper mapper, IWalkRepository walkRepository, NZWalksDbContext nZWalksDbContext)
        {
            _mapper = mapper;
            _walkRepository = walkRepository;
            _nZWalksDbContext = nZWalksDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> CreateWalk([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
          var walkDomainModels = _mapper.Map<Walk>(addWalkRequestDto);

            //await _walkRepository.CreateAsync(walkDomainModels);
            // await _nZWalksDbContext.SaveChangesAsync(); 
            var createdWalk = await _walkRepository.CreateAsync(walkDomainModels);

            var walkDto = _mapper.Map<WalkDto>(createdWalk);

            return Ok(walkDto);


           // return Ok(_mapper.Map<WalkDto>(walkDomainModels));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
          var DomainModels =  await _walkRepository.GetAll();
         //maping domainmodel to walkdto
          return Ok(_mapper.Map<List<WalkDto>>(DomainModels));
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid Id)
        {
          var domainModel = _walkRepository.GetById(Id);
          return Ok(_mapper.Map<WalkDto>(domainModel));

        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> updateAsync([FromRoute] Guid id, UpdateRegionRequestDto updateRegionRequestDto)
        {
          var walkDomainModel =  _mapper.Map<Walk>(updateRegionRequestDto);
            walkDomainModel = await _walkRepository.UpdateAsync(id, walkDomainModel);
            if(walkDomainModel == null)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
          var domainModel =await _walkRepository.DeleteAsync(id);
            return Ok(_mapper?.Map<WalkDto>(domainModel));
        }


    }
}
