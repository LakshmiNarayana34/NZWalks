using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Repositories
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext dbContext;
        public SQLWalkRepository(NZWalksDbContext dbContext) 
        {
         this.dbContext = dbContext;
        }
        public async Task<Walk> CreateAsync(Walk walk)
        {
            await dbContext.AddAsync(walk);
            await dbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk> DeleteAsync(Guid id)
        {
           var domainModel = await dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (domainModel == null)
            {
                return null;
            }

            dbContext.Walks.Remove(domainModel);
            await dbContext.SaveChangesAsync();
            return domainModel;

        }

        public async Task<List<Walk>> GetAll()
        {
           return  await dbContext.Walks.Include("Difficulty").Include("Region").ToListAsync();
            
        }

        public async Task<Walk> GetById(Guid id)
        {
          return await dbContext.Walks
                                .Include("Region")
                                .Include("Difficulty")
                                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Walk> UpdateAsync(Guid id,Walk walk)
        {
           var walkRegionRequest = await dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (walkRegionRequest == null)
            {
                return null;
            }

            walkRegionRequest.Name = walk.Name;
            walkRegionRequest.Description = walk.Description;
            walkRegionRequest.LengthInKm = walk.LengthInKm;
            walkRegionRequest.WalkImageUrl = walk.WalkImageUrl;
            walkRegionRequest.RegionId = walk.RegionId;
            walkRegionRequest.DifficultyId = walk.DifficultyId;
          
            await dbContext.SaveChangesAsync();

            return walkRegionRequest;

        }
    }
}
