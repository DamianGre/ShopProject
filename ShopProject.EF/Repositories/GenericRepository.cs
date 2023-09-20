using Microsoft.EntityFrameworkCore;
using ShopProject.Repositories;

namespace ShopProject.EF.Repositories
{
    public class GenericRepository<T> :IGenericRepository<T> where T : class
    {
        protected readonly ShopProjectDbContext _context;
        protected readonly DbSet<T> _objectSet;

        public GenericRepository(ShopProjectDbContext context)
        {
            _context = context;
            _objectSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        { 
            return await _objectSet.ToListAsync();
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _objectSet.FindAsync(id);
        }

        public async Task CreateAsync(T entity)
        { 
            await _objectSet.AddAsync(entity);
        }

        public void Update(T entity)
        {         
            _objectSet.Update(entity); 
        }

        public void Delete(T entity) 
        {
            _objectSet.Remove(entity);
        }
    }
}
