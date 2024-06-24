using FlowersShopMVCTraining.Repository.Model;
using Microsoft.EntityFrameworkCore;

namespace FlowersShopMVCTrainingRepository
{
    public class FlowersShopDbContext : DbContext
    {
        public const string CONNECTION_STRING = "Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True;Database=FlowersShop";

        public DbSet<User> Users { get; set; }
        public DbSet<ProductDescription> ProductDescriptions { get; set; }
        public DbSet<ShopCard> ShopCards { get; set; }

        public FlowersShopDbContext() { }
        public FlowersShopDbContext(DbContextOptions<FlowersShopDbContext> contextOptions) : base(contextOptions) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(CONNECTION_STRING);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShopCard>()
                .HasOne(x => x.ProductDescription);    
        }
    }
}
