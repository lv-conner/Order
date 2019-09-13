using AutoMapper;
using Dto;
using OrderGrpcService;
using Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace GrpcOrderService
{
    public class OrderService : IOrderService
    {
        private readonly OrderRpcService.OrderRpcServiceClient _orderRpcServiceClient;
        private readonly IMapper _mapper;
        public OrderService(OrderRpcService.OrderRpcServiceClient orderRpcServiceClient, IMapper mapper)
        {
            _orderRpcServiceClient = orderRpcServiceClient;
            _mapper = mapper;
        }
        public async Task AddOrderAsync(OrderDto orderData)
        {
            var order = _mapper.Map<Order>(orderData);
            await _orderRpcServiceClient.AddOrderAsync(order);
        }

        public async Task<IEnumerable<OrderDto>> GetOrderDataAsync()
        {
            var reply = await _orderRpcServiceClient.GetOrderListAsync(new OrderListRequest());
            return _mapper.Map<IEnumerable<Order>, IEnumerable<OrderDto>>(reply.Orders);
        }

        public Task<OrderDto> GetOrderDataByOrderId(string orderId)
        {
            throw new NotImplementedException();
        }
    }
}
