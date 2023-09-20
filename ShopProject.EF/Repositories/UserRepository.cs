using Microsoft.EntityFrameworkCore;
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
            return await _objectSet.FirstOrDefaultAsync(x => x.UserName.Equals(username));
        }

        public async Task<IEnumerable<User>> GetUsersAsync(string username)
        {
            if (string.IsNullOrEmpty(username))
                return await _objectSet.ToListAsync();
            return await _objectSet.Where(x => x.UserName.Equals(username)).ToListAsync();
        }
    }
}
