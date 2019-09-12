using Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IOrderListService
    {
        Task<IEnumerable<OrderDto>> GetOrderDataAsync();
    }
}
