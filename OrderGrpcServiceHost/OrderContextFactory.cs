using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderDb
{
    public class OrderContextFactory : IDesignTimeDbContextFactory<OrderDbContext>
    {
        public OrderDbContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder().UseSqlServer("******", config =>
             {
                 config.MigrationsAssembly(typeof(OrderContextFactory).Assembly.FullName);
             });
            return new OrderDbContext(optionBuilder.Options);
        }
    }
}
