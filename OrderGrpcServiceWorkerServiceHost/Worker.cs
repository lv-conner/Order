using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OrderGrpcServerImplement;
using OrderGrpcService;
using Microsoft.Extensions.DependencyInjection;

namespace OrderGrpcServiceWorkerServiceHost
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private Server _server;
        private readonly IServiceProvider _serviceProvider;
        public Worker(IServiceProvider serviceProvider,ILogger<Worker> logger)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            if (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    _server = new Server()
                    {

                        Services = { OrderRpcService.BindService(scope.ServiceProvider.GetService<OrderRpcService.OrderRpcServiceBase>()) },
                        Ports = { new ServerPort("localhost", 8888, ServerCredentials.Insecure) }
                    };
                }
                _server.Start();
            }
            return Task.CompletedTask;
        }
        public async override Task StopAsync(CancellationToken cancellationToken)
        {
            await _server.ShutdownAsync();
        }
    }
}
