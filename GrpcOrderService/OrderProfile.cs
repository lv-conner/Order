using AutoMapper;
using Dto;
using OrderGrpcService;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrpcOrderService
{
    public class OrderProfile:Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();
        }
    }
}
