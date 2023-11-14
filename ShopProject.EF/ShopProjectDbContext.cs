using Microsoft.EntityFrameworkCore;
using ShopProject.DBModels.Entities;

namespace ShopProject.EF
{
    public class ShopProjectDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserStatus> UserStatuses { get; set; }

        public ShopProjectDbContext(DbContextOptions<ShopProjectDbContext> options) : base(options) 
        { 

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserStatus>()
                .HasMany(u => u.Users)
                .WithOne(y => y.UserStatus)
                .HasForeignKey(x => x.UserStatusId);

            //One to one relation example
            //modelBuilder.Entity<>()
            //    .HasOne(u => u.)
            //    .WithOne(y => y)
            //    .HasForeignKey<>(x => x)
        }
    }
}
