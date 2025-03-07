using AutoMapper;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Data;

namespace NZWalks.API.Mapping
{
  
  
        public class AutoMappingProfiles : Profile
        {
            public AutoMappingProfiles()
            {
                // Map Product to ProductDTO (for customers)
                // Source: Product and Destination: ProductDTO
                CreateMap<Region, RegionDto>().ReverseMap();
                // Map ProductCreateDTO to Product (for adding new product)
                // Source: ProductCreateDTO and Destination: Product
                CreateMap<AddRegionRequestDto, Region>().ReverseMap();

                //Adding data to walk
                CreateMap<AddWalkRequestDto, Walk>().ReverseMap();
                //Show data walk to walkDto
                CreateMap<Walk,WalkDto>().ReverseMap();
                CreateMap<Difficulty, DifficultyDto>().ReverseMap();
               

                CreateMap<UpdateWalkRequestDto,Walk>().ReverseMap();




            }
        }
}
