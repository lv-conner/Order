using Dto;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Test
{
    public class MemoryOrderService : IOrderService
    {
        public readonly List<OrderDto> _orderDatas;
        public MemoryOrderService()
        {
            _orderDatas = new List<OrderDto>()
            {
                 new OrderDto("牛奶",10,10,"hahah")
                ,new OrderDto("牛奶", 10, 10, "hahah")
                ,new OrderDto("牛奶", 10, 10, "hahah")
                ,new OrderDto("牛奶", 10, 10, "hahah")
                ,new OrderDto("牛奶", 10, 10, "hahah")
            };
        }
        public Task AddOrder(OrderDto orderData)
        {
            _orderDatas.Add(orderData);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<OrderDto>> GetOrderDataAsync()
        {
            return Task.FromResult(_orderDatas.AsEnumerable());
        }

        public Task<OrderDto> GetOrderDataByOrderId(string orderId)
        {
            var order = _orderDatas.FirstOrDefault(p => p.OrderId == orderId);
            return Task.FromResult(order);
        }
    }
}
