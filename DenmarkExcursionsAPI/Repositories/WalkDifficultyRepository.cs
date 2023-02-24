using DenmarkExcursionsAPI.Data;
using DenmarkExcursionsAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace DenmarkExcursionsAPI.Repositories
{
    public class WalkDifficultyRepository : IWalkDifficultyRepository
    {
        private readonly DenmarkExcursionsDbContext _denmarkExcursionsDbContext;

        public WalkDifficultyRepository(DenmarkExcursionsDbContext denmarkExcursionsDbContext)
        {
            _denmarkExcursionsDbContext = denmarkExcursionsDbContext;
        }

        public async Task<WalkDifficulty> AddAsync(WalkDifficulty walkDifficulty)
        {
            walkDifficulty.Id = Guid.NewGuid();
            await _denmarkExcursionsDbContext.WalkDifficulty.AddAsync(walkDifficulty);
            await _denmarkExcursionsDbContext.SaveChangesAsync();
            return walkDifficulty;
        }

        public async Task<IEnumerable<WalkDifficulty>> GetAllAsync()
        {
            return await _denmarkExcursionsDbContext.WalkDifficulty.ToListAsync();
        }

        public async Task<WalkDifficulty> GetAsync(Guid id)
        {
            return await _denmarkExcursionsDbContext.WalkDifficulty.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<WalkDifficulty> UpdateAsync(Guid id, WalkDifficulty walkDifficulty)
        {
            var existingWalkDifficulty = await _denmarkExcursionsDbContext.WalkDifficulty.FindAsync(id);

            if (existingWalkDifficulty == null)
            {
                return null;
            }

            existingWalkDifficulty.Code = walkDifficulty.Code;
            await _denmarkExcursionsDbContext.SaveChangesAsync();
            return existingWalkDifficulty;
        }

        public async Task<WalkDifficulty> DeleteAsync(Guid id)
        {
            var walkDifficulty = await _denmarkExcursionsDbContext.WalkDifficulty.FindAsync(id);

            if (walkDifficulty == null)
            {
                return null;
            }

            _denmarkExcursionsDbContext.WalkDifficulty.Remove(walkDifficulty);
            await _denmarkExcursionsDbContext.SaveChangesAsync();
            return walkDifficulty;
        }
    }
}
