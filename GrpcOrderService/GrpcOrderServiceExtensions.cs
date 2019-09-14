using AutoMapper;
using Grpc.Core;
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
        public static IServiceCollection AddGrpcOrderService(this IServiceCollection services, GrpcOrderServiceOptions options)
        {
            if(options.GrpcOrderServiceAddres == null)
            {
                throw new ArgumentNullException(nameof(GrpcOrderServiceOptions.GrpcOrderServiceAddres));
            }
            if(!options.GrpcOrderServiceAddres.IsAbsoluteUri)
            {
                throw new ArgumentException($"{nameof(GrpcOrderServiceOptions.GrpcOrderServiceAddres)} isn't absolute uri!");
            }
            Action<GrpcClientFactoryOptions> configureClient = op =>
            {
                op.Address = options.GrpcOrderServiceAddres;
                if (!options.IsHttps)
                {
                    AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
                    op.ChannelOptionsActions.Add(channelOptions =>
                    {
                        channelOptions.Credentials = ChannelCredentials.Insecure;
                    });
                }
            };
            services.AddGrpcClient<OrderRpcService.OrderRpcServiceClient>(configureClient);
            services.AddAutoMapper(typeof(GrpcOrderServiceExtensions).Assembly);
            services.AddScoped<IAddOrderService, OrderService>();
            services.AddScoped<IOrderListService, OrderService>();
            services.AddScoped<IOrderService, OrderService>();
            return services;
        }
    }
}
