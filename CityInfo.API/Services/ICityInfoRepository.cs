using CityInfo.API.Entities;

namespace CityInfo.API.Services
{
    public interface ICityInfoRepository
    {
        Task<IEnumerable<City>> GetCitiesAsync();
        Task<City?> GetCityAsync(int cityId, bool includePointsOfInterest);
        Task<IEnumerable<PointOfInterest>> GetPointsOfInterestForCityAsync(int cityID);
        Task<bool> CityExistAsync(int cityID);
        Task<PointOfInterest?> GetPointOfInterestForCityAsync(int cityID, int pointOfInterestId);
        Task AddPointOfInterestForCityAsync(int cityId, PointOfInterest pointOfInterest);
        Task<bool> SaveChangesAsync();
    }
}
