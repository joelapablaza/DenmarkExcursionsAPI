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
        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await _denmarkExcursionsDbContext.Regions.ToListAsync();


        }
    }
}
