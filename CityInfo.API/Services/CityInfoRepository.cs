﻿using CityInfo.API.DbContexts;
using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API.Services
{
    public class CityInfoRepository : ICityInfoRepository
    {
        private readonly CityInfoContext _context;
        public CityInfoRepository(CityInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await _context.Cities.OrderBy(c => c.Name).ToListAsync();
        }

        public async Task<IEnumerable<City>> GetCitiesAsync(string? name,string? searchQuery)
        {
            if(string.IsNullOrEmpty(name) && string .IsNullOrWhiteSpace(searchQuery
                ))
            {
                return await GetCitiesAsync();
            }
            var collection =_context.Cities as IQueryable<City>;
            if(!string .IsNullOrWhiteSpace(name))
            {
                name = name.Trim();
                collection =collection.Where(c => c.Name == name);
            }
            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                searchQuery= searchQuery.Trim();
                collection=collection.Where(a=> a.Name.Contains(searchQuery)
                || (a.Description != null && a.Description.Contains(searchQuery)));
            }
            return await collection.OrderBy(c => c.Name).ToListAsync();

            name = name.Trim();
            return await  _context.Cities
                .Where(c => c.Name == name)
                .OrderBy(c => c.Name)
                .ToListAsync();
        }

        public async Task<City?> GetCityAsync(int cityId, bool includePointsOfInterest)
        {
            if (includePointsOfInterest)
            {
                return await _context.Cities.Include(c => c.PointsOfInterest).Where(c => c.Id == cityId)
                         .FirstOrDefaultAsync();
            }
            return await _context.Cities
                .Where(c => c.Id == cityId)
                           .FirstOrDefaultAsync();
        }
        public async Task<bool> CityExistAsync(int cityId)
        {
            return await _context.Cities.AnyAsync(c => c.Id == cityId);
        }

        public async Task<PointOfInterest?> GetPointOfInterestForCityAsync(int cityID, int pointOfInterestId)
        {
            return await _context.PointsOfInterest
                .Where(p => p.CityId == cityID && p.Id == pointOfInterestId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PointOfInterest>> GetPointsOfInterestForCityAsync(int cityID)
        {
            return await _context.PointsOfInterest
                .Where(p => p.CityId == cityID).ToListAsync();

        }
        public async Task AddPointOfInterestForCityAsync(int cityId,PointOfInterest pointOfInterest)
        {
            var city = await GetCityAsync(cityId, false);
            if(city != null)
            {
                city.PointsOfInterest.Add(pointOfInterest);
            }

        }

        public void DeletePointOfInterest(PointOfInterest pointOfInterest)
        {
            _context.PointsOfInterest.Remove(pointOfInterest);
        }
        public async Task <bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >=0);
        }

        public Task<IEnumerable<City>> GetAllCitiesAsync(string? name)
        {
            throw new NotImplementedException();
        }
    }

       
}
