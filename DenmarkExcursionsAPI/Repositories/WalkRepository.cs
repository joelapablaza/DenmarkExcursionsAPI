using DenmarkExcursionsAPI.Data;
using DenmarkExcursionsAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DenmarkExcursionsAPI.Repositories
{
    public class WalkRepository : IWalkRepository
    {
        private readonly DenmarkExcursionsDbContext _denmarkExcursionsDbContext;

        public WalkRepository(DenmarkExcursionsDbContext denmarkExcursionsDbContext)
        {
            _denmarkExcursionsDbContext = denmarkExcursionsDbContext;
        }

        public async Task<IEnumerable<Walk>> GetAllAsync()
        {
            return await _denmarkExcursionsDbContext.Walks
                .Include(x => x.Region)
                .Include(x => x.WalkDifficulty)
                .ToListAsync();
        }

        public async Task<Walk> GetAsync(Guid id)
        {
            return await _denmarkExcursionsDbContext.Walks
                .Include(x => x.Region)
                .Include(x => x.WalkDifficulty)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Walk> AddAsync(Walk walk)
        {
            walk.Id = Guid.NewGuid();

            await _denmarkExcursionsDbContext.Walks.AddAsync(walk);
            await _denmarkExcursionsDbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk> UpdateAsync(Guid id, Walk walk)
        {
            var existingWalk = await _denmarkExcursionsDbContext.Walks.FindAsync(id);

            if (existingWalk != null)
            {
                existingWalk.Length = walk.Length;
                existingWalk.WalkDifficultyId = walk.WalkDifficultyId;
                existingWalk.Name = walk.Name;
                existingWalk.RegionId = walk.RegionId;

                await _denmarkExcursionsDbContext.SaveChangesAsync();
                return existingWalk;
            }
            return null;
        }

        public async Task<Walk> DeleteAsync(Guid id)
        {
            var walk = await _denmarkExcursionsDbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);

            if (walk != null)
            {
                _denmarkExcursionsDbContext.Walks.Remove(walk);
                await _denmarkExcursionsDbContext.SaveChangesAsync();
            }

            return walk;
        }
    }
}
