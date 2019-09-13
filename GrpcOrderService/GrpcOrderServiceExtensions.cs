using AutoMapper;
using Grpc.Net.ClientFactory;
using GrpcOrderService;
using OrderGrpcService;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class GrpcOrderServiceExtensions
    {
        public static IServiceCollection AddGrpcOrderService(this IServiceCollection services, Action<GrpcClientFactoryOptions> configureClient)
        {
            services.AddGrpcClient<OrderRpcService.OrderRpcServiceClient>(configureClient);
            services.AddAutoMapper(typeof(GrpcOrderServiceExtensions).Assembly);
            services.AddScoped<IAddOrderService, OrderService>();
            services.AddScoped<IOrderListService, OrderService>();
            services.AddScoped<IOrderService, OrderService>();
            return services;
        }
    }
}
