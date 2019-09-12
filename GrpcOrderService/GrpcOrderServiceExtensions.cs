using GrpcOrderService;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class GrpcOrderServiceExtensions
    {
        public static IServiceCollection AddGrpcOrderService(this IServiceCollection services)
        {
            services.AddSingleton<IOrderService, OrderService>();
            return services;
        }
    }
}
