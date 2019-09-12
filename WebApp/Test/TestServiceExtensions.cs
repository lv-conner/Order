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
            services.AddSingleton<IOrderService, MemoryOrderService>();
            return services;
        }
    }
}
