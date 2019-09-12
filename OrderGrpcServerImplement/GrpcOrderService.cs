using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using OrderGrpcService;
using System;
using System.Threading.Tasks;

namespace OrderGrpcServerImplement
{
    public class GrpcOrderService: OrderRpcService.OrderRpcServiceBase
    {
        public override Task<Empty> AddOrder(Order request, ServerCallContext context)
        {
            return base.AddOrder(request, context);
        }
        public override Task<OrderListReply> GetOrderList(OrderListRequest request, ServerCallContext context)
        {
            return base.GetOrderList(request, context);
        }
    }
}
