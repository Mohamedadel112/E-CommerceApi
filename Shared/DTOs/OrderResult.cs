using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public record OrderResultDTO
    {
        public Guid Id { get; set; }
        public string UserEmail { get; init; }
        public AddressDTO ShippingAddress { get; init; }

        public ICollection<OrderItemsDTO> OrderItems { get; init; } = new List<OrderItemsDTO>();
        public string OrderPaymentStatus { get; init; } 
        public string DeliveryMethod { get; init; }
        public DateTimeOffset OrderDate { get; init; } = DateTimeOffset.Now;

        public decimal SupTotal { get; init; } // Price of Orderitem * Quantity // Total = Subtotal + Shipping 

        public string PaymentintentId { get; init; } = string.Empty;
        public decimal Total { get; init; }
    }
}
