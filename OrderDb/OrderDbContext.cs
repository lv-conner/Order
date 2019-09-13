using Microsoft.EntityFrameworkCore;
using OrderDb.EntityMaps;
using System;

namespace OrderDb
{
    public class OrderDbContext:DbContext
    {
        public OrderDbContext(DbContextOptions options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderMap());
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
