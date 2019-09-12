using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Test;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class TestServiceExtensions
    {
        public static IServiceCollection AddTestService(this IServiceCollection services)
        {
            var service = new MemoryOrderService();
            services.AddSingleton<IOrderService>(service);
            services.AddSingleton<IAddOrderService>(service);
            services.AddSingleton<IOrderListService>(service);
            return services;
        }
    }
}
