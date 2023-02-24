using DenmarkExcursionsAPI.Data;
using DenmarkExcursionsAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace DenmarkExcursionsAPI.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly DenmarkExcursionsDbContext _denmarkExcursionsDbContext;

        public RegionRepository(DenmarkExcursionsDbContext denmarkExcursionsDbContext)
        {
            _denmarkExcursionsDbContext = denmarkExcursionsDbContext;
        }

        // Get All Regions
        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await _denmarkExcursionsDbContext.Regions.ToListAsync();
        }

        // Get One Region by Id
        public async Task<Region> GetAsync(Guid id)
        {
            return await  _denmarkExcursionsDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        // Create One Region
        public async Task<Region> AddAsync(Region region)
        {
            region.Id = Guid.NewGuid();
            await _denmarkExcursionsDbContext.AddAsync(region);
            await _denmarkExcursionsDbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region> DeleteAsync(Guid id)
        {
            var region = await _denmarkExcursionsDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (region != null) 
            {
                _denmarkExcursionsDbContext.Regions.Remove(region);
                await _denmarkExcursionsDbContext.SaveChangesAsync();
            }

            return region;
        }

        public async Task<Region> UpdateAsync(Guid id, Region region)
        {
            var regionUpdate = await _denmarkExcursionsDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        
            if (regionUpdate != null)
            {
                regionUpdate.Code = region.Code;
                regionUpdate.Name= region.Name;
                regionUpdate.Area = region.Area;
                regionUpdate.Long = region.Long;
                regionUpdate.Lat = region.Lat;
                regionUpdate.Population = region.Population;

                await _denmarkExcursionsDbContext.SaveChangesAsync();
            }

            return regionUpdate;
        }
    }
}
