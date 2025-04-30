
using ShippingAddr = Domain.Entities.OrderEntity.Address;

namespace Domain.Entities.OrderEntity
{
    public class Order  :BaseEntity<Guid>
    {
        public Order(string userEmail,
            ShippingAddr shippingAddress,  
            ICollection<OrderItem> orderItems,  
            DeliveryMethods deliveryMethod,
            decimal supTotal)
        {
            UserEmail = userEmail;
            ShippingAddress = shippingAddress;
            OrderItems = orderItems;
            DeliveryMethod = deliveryMethod;
            SupTotal = supTotal;
        }
        public Order()
        {
            
        }

        public string UserEmail { get; set; }
        public ShippingAddr ShippingAddress { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public OrderPaymentStatus OrderPaymentStatus { get; set; } = OrderPaymentStatus.pending;
        public DeliveryMethods DeliveryMethod { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public int? DeliveryMethodId { get; set; } // FK

        public decimal SupTotal { get; set; } // Price of Orderitem * Quantity // Total = Subtotal + Shipping 

        public string PaymentintentId { get; set; } = string.Empty;

    }
}
