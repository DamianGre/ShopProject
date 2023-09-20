using Microsoft.EntityFrameworkCore;
using ShopProject.DBModels.Entities;

namespace ShopProject.EF
{
    public class ShopProjectDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ShopProjectDbContext(DbContextOptions<ShopProjectDbContext> options) : base(options) 
        { 

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
