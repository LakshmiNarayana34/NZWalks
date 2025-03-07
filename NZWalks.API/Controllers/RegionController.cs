using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;
using System.Collections.Generic;


namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class RegionController : ControllerBase
    {

       


        //this is NZWalksDbContext class we want to retreive data from database
        private readonly NZWalksDbContext dbContext; //this is private field we can create constructor

        private readonly IRegionRepository regionRepository;
       
        public RegionController(NZWalksDbContext dbContext, IRegionRepository regionRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
           
        }

        //GET All REGIONS
        //GET: https:localhost:portNumber/api/regions
        [HttpGet]
      //  [Authorize(Roles = "Reader,Writer")]
        public async Task<IActionResult> GetAll()
        {
            //Get Data from  Database - Domain models
            // var regions = await dbContext.Regions.ToListAsync();//dbContext variable . Regions Class 
            var regions = await regionRepository.GetAllAsync();

       // var del =  mapper.Map<List<RegionDto>>(regions);

            //Map Domain Models to DTOs
            var regionsDto = new List<RegionDto>();

            foreach (var region in regions) {


                regionsDto.Add(new RegionDto()
                {
                    Id = region.Id,
                    Code = region.Code,
                    Name = region.Name,
                    RegionImgUrl = region.RegionImgUrl

                });
            }

            /*
                        var regions = new List<Region>
                        {
                            new Region
                            {
                                Id = Guid.NewGuid(),
                                Name = "Lakshmi Narayana",
                                Code = "Ind",
                                RegionImgUrl ="https://www.pexels.com/photo/woman-taking-photos-on-a-seaside-beach-29715958/"
                            },
                             new Region
                            {
                                Id = Guid.NewGuid(),
                                Name = "Narayana",
                                Code = "Aus",
                                RegionImgUrl ="https://www.pexels.com/photo/cozy-winter-latte-in-graz-austria-29784884/"
                            }
                        };*/

            return Ok(regionsDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
      //  [Authorize(Roles = "Reader,Writer")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            // var region = dbContext.Regions.Find(id);
            //Get Region Domain Model From Database
           // var region = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
           var regionDomain = await regionRepository.GetAllByIdAsync(id);
            if (regionDomain == null) {
                return NotFound();
            }

           var regions = new RegionDto
            {
                Id= regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImgUrl= regionDomain.RegionImgUrl
            };

            //Map/Convert Region Domain Model to Region DTO

           
            return Ok(regions);
        }

        //Post to Create New Region
        //Post : https://localhost:portnumber/api/regions
        [HttpPost]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            //Map or Convert DTO to Domain Model

            if (ModelState.IsValid)
            {

                var regionDomainModel = new Region
                {
                    Code = addRegionRequestDto.Code,
                    Name = addRegionRequestDto.Name,
                    RegionImgUrl = addRegionRequestDto.RegionImgUrl
                };

                //Use Domain model to create Region
                // await dbContext.Regions.AddAsync(regionDomainModel);
                //await dbContext.SaveChangesAsync();

                regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);


                //Map Domain model back to Dto
                var regionDto = new RegionDto
                {

                    Id = regionDomainModel.Id,
                    Code = regionDomainModel.Code,
                    Name = regionDomainModel.Name,
                    RegionImgUrl = regionDomainModel.RegionImgUrl
                };

                return CreatedAtAction(nameof(GetById), new { id = regionDomainModel.Id }, regionDto);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("{id:guid}")]
      //  [Authorize(Roles = "Writer")]

        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            //find the data which will be updated using id
            /*
             * var RegionDomainModel= await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
              if(RegionDomainModel == null)
              {
                  return NotFound();
              }
              RegionDomainModel.Code = updateRegionRequestDto.Code;
              RegionDomainModel.Name = updateRegionRequestDto.Name;
              RegionDomainModel.RegionImgUrl = updateRegionRequestDto.RegionImgUrl;

              await dbContext.SaveChangesAsync();

              */
          var DomainModel =  new Region
            {
                Name = updateRegionRequestDto.Name,
                Code = updateRegionRequestDto.Code,
                RegionImgUrl= updateRegionRequestDto.RegionImgUrl
            };

          var RegionDomainModel =  await regionRepository.UpdateAsync(id, DomainModel);

            //expose the updated data
            var regionDto = new RegionDto
            {
                Id = RegionDomainModel.Id,
                Code = RegionDomainModel.Code,
                Name = RegionDomainModel.Name,
                RegionImgUrl = RegionDomainModel.RegionImgUrl
            };

            return Ok(regionDto);

        }


        [HttpDelete]
        [Route("{id:guid}")]
      //  [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id) 
        {
            var regionDomainModel = await regionRepository.DeleteAsync(id);
         //  var regionDomainModel = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
           if (regionDomainModel == null)
           {
                return NotFound();
           }
          
           dbContext.Regions.Remove(regionDomainModel);
           await dbContext.SaveChangesAsync();

            //Deleted data exposed
            var regionDto = new RegionDto
            {
                Id= regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImgUrl= regionDomainModel.RegionImgUrl

            };

            return Ok(regionDto);


        }
    }
}
