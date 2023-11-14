using ShopProject.DBModels.Entities;

namespace ShopProject.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByIdAsync(int userId);
        Task<User> GetUserByUserNameAsync(string username);
        Task<IEnumerable<User>> GetUsersAsync(string username);
        Task<IEnumerable<string>> GetUsersByNameKeywordAsync(string name);
    }
}
