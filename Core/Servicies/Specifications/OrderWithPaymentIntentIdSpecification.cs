using Domain.Contracts;
using Domain.Entities.OrderEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Servicies.Specifications
{
    public class OrderWithPaymentIntentIdSpecification : Specification<Order>
    {
        public OrderWithPaymentIntentIdSpecification(string  PaymentIntentId) : base(o=>o.PaymentintentId ==PaymentIntentId)
        {
        }
    }
}
