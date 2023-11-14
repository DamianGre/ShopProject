using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ShopProject.DBModels.Entities;
using ShopProject.Repositories;

namespace ShopProject.EF.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository 
    {
        public UserRepository(ShopProjectDbContext context) : base(context) 
        { 

        }

        public async Task<User> GetByIdAsync(int userId)
        {
            return await _objectSet.FindAsync(userId);
        }

        public async Task<User> GetUserByUserNameAsync(string username)
        {
            return await _objectSet.FirstOrDefaultAsync(x => x.Name.Equals(username));
        }

        public async Task<IEnumerable<User>> GetUsersAsync(string username)
        {
            if (string.IsNullOrEmpty(username))
                return await _objectSet.ToListAsync();
            return await _objectSet.Where(x => x.Name.Equals(username)).ToListAsync();
        }

        public async Task<IEnumerable<string>> GetUsersByNameKeywordAsync(string name) 
        { 
            if(string.IsNullOrEmpty(name))
                return await _objectSet.Select(x => x.Name).Distinct().ToListAsync();
            return await _objectSet.Where(x => x.Name.StartsWith(name)).Select(y => y.Name).Distinct().ToListAsync();
        }
    }
}
