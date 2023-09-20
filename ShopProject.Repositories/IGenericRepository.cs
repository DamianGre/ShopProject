﻿namespace ShopProject.Repositories
{
    public interface IGenericRepository<T>  where T :class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task CreateAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
