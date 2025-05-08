using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.OrderEntity
{
    public class DeliveryMethods : BaseEntity<int>
    {
        public DeliveryMethods(string shortname, string description, string deliveryTime, decimal price)
        {
            Shortname = shortname;
            Description = description;
            DeliveryTime = deliveryTime;
            Price = price;
        }
        public DeliveryMethods()
        {
            
        }
        public string? Shortname { get; set; }
        public string Description { get; set; }
        public string DeliveryTime { get; set; }
        public decimal Price { get; set; }
    }
}
