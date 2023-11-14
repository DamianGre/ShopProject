using ShopProject.EF.Repositories;
using ShopProject.Repositories;

namespace ShopProject.EF
{
    public class ShopProjectUnitOfWork : IShopProjectUnitOfWork, IDisposable
    {
        private readonly ShopProjectDbContext _context;

        public ShopProjectUnitOfWork(ShopProjectDbContext context)
        {
            _context = context;
        }

        private IUserRepository _userRepository;
        public IUserRepository UserRepository 
        { 
            get 
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_context);
                return _userRepository;
            } 
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task SaveChangesAsync()
        { 
            await _context.SaveChangesAsync();
        }
    }
}
