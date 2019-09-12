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

namespace OrderGrpcServiceWorkerServiceHost
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private Server _server;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            if (!stoppingToken.IsCancellationRequested)
            {
                _server = new Server()
                {
                    Services = { OrderRpcService.BindService(new GrpcOrderService()) },
                    Ports = { new ServerPort("localhost", 9999, ServerCredentials.Insecure) }
                };
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
