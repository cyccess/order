using Cyc.Order.Data.DataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace Cyc.Order.Data
{
    public partial class OrderDbContext : DbContext
    {

        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {

        }

        public DbSet<Goods> Goods { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<OrderRecord> OrderRecords { get; set; }
        public DbSet<OrderRecordDetail> OrderRecordDetails { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<GoodsPrice> GoodsPrices { get; set; }
        public DbSet<Region> Regions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Goods>().ToTable("order_goods");
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //  => optionsBuilder.UseMySQL(@"Server=localhost;database=order;uid=root;pwd=111aaa;SslMode=None");

    }
}
