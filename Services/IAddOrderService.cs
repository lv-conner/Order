using Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IAddOrderService
    {
        Task AddOrderAsync(OrderDto orderData);
    }
}
