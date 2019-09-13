using OrderDb;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderGrpcRepository
{
    public class OrderDbRepository<T> : EFCoreRepository.EFCoreRepository<T, OrderDbContext> where T : class
    {
        public OrderDbRepository(OrderDbContext context) : base(context)
        {

        }
    }
}
