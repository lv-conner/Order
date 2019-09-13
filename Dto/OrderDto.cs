using System;
using System.ComponentModel.DataAnnotations;

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
        [Required(AllowEmptyStrings = false,ErrorMessage = "Product name is required!")]
        public string ProductName { get; set; } = "";
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must greater or equal to 0!")]
        public int Quantity { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "UnitPrice must greater or equal to 0!")]
        public int UnitPrice { get; set; }
        [MaxLength(200,ErrorMessage = "Remark should less than 200!")]
        public string Remark { get; set; } = "";
    }
}
