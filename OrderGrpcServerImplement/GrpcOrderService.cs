using Entity;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using OrderGrpcService;
using Repository;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace OrderGrpcServerImplement
{
    public class GrpcOrderService: OrderRpcService.OrderRpcServiceBase
    {
        private readonly IRepository<OrderEntity> _repository;
        private static Empty SuccessResponse = new Empty();
        public GrpcOrderService(IRepository<OrderEntity> repository)
        {
            _repository = repository;
        }
        public override async Task<Empty> AddOrder(Order request, ServerCallContext context)
        {
            var orderEntity = new OrderEntity(request.ProductName, request.Quantity, request.UnitPrice, request.Remark);
            await _repository.AddAsync(orderEntity);
            return SuccessResponse;
        }
        public override async Task<OrderListReply> GetOrderList(OrderListRequest request, ServerCallContext context)
        {
            var list = await _repository.QueryAllAsync(p => new Order()
            {
                OrderId = p.OrderId,
                ProductName = p.ProductName,
                Quantity = p.Quantity,
                UnitPrice = p.UnitPrice,
                Remark = p.Remark
            });
            var reply = new OrderListReply();
            reply.Orders.AddRange(list);
            return reply;
        }
    }
}
