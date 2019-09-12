using Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetOrderDataAsync();
        Task AddOrder(OrderDto orderData);
        Task<OrderDto> GetOrderDataByOrderId(string orderId);
    }
}
