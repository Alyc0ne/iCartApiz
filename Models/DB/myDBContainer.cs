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
            modelBuilder.Entity<view_GoodsUnit>().HasNoKey();
            
        }

        public DbSet<Goods> Goods { get; set; }
        public DbSet<GoodsUnit> GoodsUnit { get; set; }
        public DbSet<Unit> Unit { get; set; }

        //View
        public DbSet<view_GoodsUnit> view_GoodsUnit { get; set; }
    }
}