using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrderGrpcServerImplement;
using OrderGrpcService;

namespace OrderGrpcServiceWorkerServiceHost
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddOrderGrpcRepository(options =>
                    {
                        options.UseSqlServer(hostContext.Configuration.GetValue<string>("OrderConnectionString"), config =>
                        {
                        });
                    });
                    services.AddOrderGrpcRepository();
                    services.AddScoped<OrderRpcService.OrderRpcServiceBase, GrpcOrderService>();
                    services.AddHostedService<Worker>();
                });
    }
}
