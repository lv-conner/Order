using System;

namespace Dto
{
    public class OrderDto
    {
        public OrderDto()
        {

        }

        public OrderDto(string orderId, string productName, int quantity, int unitprice, string remark = null)
        {
            OrderId = orderId;
            ProductName = productName;
            Quantity = quantity;
            UnitPrice = unitprice;
            Remark = remark;
        }
        public OrderDto(string productName, int quantity, int unitprice, string remark = null)
            : this(Guid.NewGuid().ToString().Substring(0,4), productName, quantity, unitprice, remark)
        {
        }
        public string OrderId { get; private set; } = "";
        public string ProductName { get; set; } = "";
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        public string Remark { get; set; } = "";
    }
}
