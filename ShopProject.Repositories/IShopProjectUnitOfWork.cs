namespace ShopProject.Repositories
{
    public interface IShopProjectUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }

        Task SaveChangesAsync();
    }
}
