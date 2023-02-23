using DenmarkExcursionsAPI.Models.Domain;

namespace DenmarkExcursionsAPI.Repositories
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAllAsync();
    }
}
