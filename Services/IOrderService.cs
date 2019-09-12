using Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public interface IOrderService : IAddOrderService, IOrderListService
    {
        Task<OrderDto> GetOrderDataByOrderId(string orderId);
    }
}
