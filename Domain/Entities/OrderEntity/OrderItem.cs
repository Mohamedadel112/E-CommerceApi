using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.OrderEntity
{
    public class OrderItem :BaseEntity<Guid>
    {
        public OrderItem(ProductInOrder product, int quantity, decimal price)
        {
            Product = product;
            Quantity = quantity;
            Price = price;
        }

        public OrderItem()
        {
            
        }
        public ProductInOrder Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
