using Microsoft.EntityFrameworkCore;

namespace iCartApi.Models
{
    public class GoodsContext : DbContext
    {
        public GoodsContext(DbContextOptions<GoodsContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<view_GoodsUnit>()
                .HasNoKey();
            // modelBuilder.Entity<view_GoodsUnit>(eb =>
            // {
            //     eb.HasNoKey();
            //     eb.ToView("view_GoodsUnit");
            //     eb.Property(v => v.GoodsUnitID).HasColumnName("GoodsUnitID");
            // });
        }

        public DbSet<Goods> Goods { get; set; }
        public DbSet<view_GoodsUnit> view_GoodsUnit { get; set; }
    }
}