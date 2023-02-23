using DenmarkExcursionsAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace DenmarkExcursionsAPI.Data
{
    public class DenmarkExcursionsDbContext : DbContext
    {
        public DenmarkExcursionsDbContext(DbContextOptions<DenmarkExcursionsDbContext> options): base(options)
        {
        }

        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<WalkDifficulty> WalkDifficulty { get; set; }
    }
}
