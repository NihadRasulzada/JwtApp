using JwtApp.Back.Core.Domain;
using JwtApp.Back.Persistance.Configurations;
using Microsoft.EntityFrameworkCore;

namespace JwtApp.Back.Persistance.Context
{
    public class AppDbContext : DbContext
    {
        #region AppDbContext
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        #endregion

        #region OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
        }
        #endregion

        public DbSet<Product> Products => this.Set<Product>();
        public DbSet<Category> Categories => this.Set<Category>();
        public DbSet<AppUser> AppUsers => this.Set<AppUser>();
        public DbSet<AppRole> AppRoles => this.Set<AppRole>();
    }
}
