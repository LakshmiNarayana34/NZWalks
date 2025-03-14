﻿using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IWalkRepository
    {
        Task<Walk> CreateAsync(Walk walk);

        Task <List<Walk>> GetAll();

        Task<Walk>GetById(Guid id);

        Task<Walk> UpdateAsync(Guid id,Walk walk);

        Task<Walk> DeleteAsync(Guid id);

    }
}
