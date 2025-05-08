using Domain.Contracts;
using Domain.Entities.OrderEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicies.Specifications
{
    public class OrderIncludeSpecification : Specification<Order>
    {
        public OrderIncludeSpecification(Guid id) : base(i=>i.Id==id)
        {
            AddInclude(o => o.DeliveryMethod);
            AddInclude(o => o.OrderItems);
            
            
        }
        public OrderIncludeSpecification(string Email) :base(e=>e.UserEmail==Email)
        {
            AddInclude(o => o.DeliveryMethod);
            AddInclude(o => o.OrderItems);
            SetOrder(o => o.OrderDate);
        }
    }
}
