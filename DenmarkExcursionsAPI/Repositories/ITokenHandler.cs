using DenmarkExcursionsAPI.Models.Domain;

namespace DenmarkExcursionsAPI.Repositories
{
    public interface ITokenHandler
    {
        Task<string> CreateTokenAsync(User user);
    }
}
