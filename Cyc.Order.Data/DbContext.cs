using Cyc.Order.Data.DataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace Cyc.Order.Data
{
    public partial class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public static DbContext orderContext;

        public static DbContext Instance(){
            if(orderContext == null)
            {
                orderContext = new DbContext();
            }

            return orderContext;
        }


        public DbSet<Goods> Goods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Goods>().ToTable("order_goods");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
          => optionsBuilder.UseMySQL(@"Server=localhost;database=order;uid=root;pwd=111aaa;SslMode=None");

    }
}
