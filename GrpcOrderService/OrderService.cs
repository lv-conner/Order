using Dto;
using OrderGrpcService;
using Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrpcOrderService
{
    public class OrderService : IOrderService
    {
        private readonly OrderRpcService.OrderRpcServiceClient _orderRpcServiceClient;
        public OrderService(OrderRpcService.OrderRpcServiceClient orderRpcServiceClient)
        {
            _orderRpcServiceClient = orderRpcServiceClient;
        }
        public Task AddOrder(OrderDto orderData)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderDto>> GetOrderDataAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OrderDto> GetOrderDataByOrderId(string orderId)
        {
            throw new NotImplementedException();
        }
    }
}
