using DenmarkExcursionsAPI.Models.Domain;

namespace DenmarkExcursionsAPI.Repositories
{
    public interface IUserRepository
    {
        Task<User> AuthenticateAsync(string username, string password);
    }
}
