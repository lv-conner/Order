using Microsoft.EntityFrameworkCore;
using OrderDb;
using OrderGrpcRepository;
using Repository;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class OrderGrpcServiceExtensions
    {
        public static IServiceCollection AddOrderGrpcRepository(this IServiceCollection services,Action<DbContextOptionsBuilder> options)
        {
            services.AddScoped(typeof(IRepository<>), typeof(OrderDbRepository<>));
            services.AddDbContext<OrderDbContext>(options);
            return services;
        }
    }
}
