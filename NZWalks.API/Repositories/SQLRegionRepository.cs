﻿using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext dbContext;

        public SQLRegionRepository(NZWalksDbContext dbContext)
        {
         this.dbContext = dbContext;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await dbContext.Regions.ToListAsync();
        }

       

        public async Task<Region?> GetAllByIdAsync(Guid id)
        {
          return await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region> CreateAsync(Region region)
        {
           await dbContext.Regions.AddAsync(region);
            await dbContext.SaveChangesAsync();
            return region;
        }

        

        public async Task<Region> DeleteAsync(Guid id)
        {
          var existingRegion = await  dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRegion != null)
            {
                return null;
            }
            dbContext.Regions.Remove(existingRegion);
            await dbContext.SaveChangesAsync();
            return existingRegion;
        }

        public async Task<Region> UpdateAsync(Guid id, Region region)
        {
            var existingRegion =  await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
           
            await dbContext.SaveChangesAsync();

            if (existingRegion == null)
            {
                return null;
            }

            existingRegion.Name = region.Name;
            existingRegion.Code = region.Code;
            existingRegion.RegionImgUrl = region.RegionImgUrl;
            await dbContext.SaveChangesAsync();
            return existingRegion;

        }
    }
}
