using Microsoft.EntityFrameworkCore;

namespace iCartApi.Models
{
    public class myDBContainer : DbContext
    {
        public myDBContainer(DbContextOptions<myDBContainer> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<view_ProductsUnit>().HasNoKey();
            
        }

        public DbSet<Products> Products { get; set; }
        public DbSet<ProductsUnit> ProductsUnit { get; set; }
        public DbSet<Unit> Unit { get; set; }

        //View
        public DbSet<view_ProductsUnit> view_ProductsUnit { get; set; }
    }
}