using DenmarkExcursionsAPI.Data;
using DenmarkExcursionsAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace DenmarkExcursionsAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DenmarkExcursionsDbContext _denmarkExcursionsDbContext;

        public UserRepository(DenmarkExcursionsDbContext denmarkExcursionsDbContext)
        {
            _denmarkExcursionsDbContext = denmarkExcursionsDbContext;
        }
        public async Task<User> AuthenticateAsync(string username, string password)
        {
            var user = await _denmarkExcursionsDbContext.Users
                 .FirstOrDefaultAsync(x => x.UserName.ToLower() == username.ToLower() &&
                 x.Password == password);

            if (user == null)
            {
                return null;
            }

            var userRoles = await _denmarkExcursionsDbContext
                .Users_Roles.Where(x => x.UserId == user.Id).ToListAsync();

            if (userRoles.Any())
            {
                user.Roles = new List<string>();
                foreach (var userRole in userRoles)
                {
                    var role = await _denmarkExcursionsDbContext.Roles.FirstOrDefaultAsync(
                        x => x.Id == userRole.RoleId);

                    if (role != null)
                    {
                        user.Roles.Add(role.Name);
                    }
                }
            }

            user.Password = null;
            return user;
        }
    }
}
