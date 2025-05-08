using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{ 
    public sealed class DeliveryMethodsNotFound : NotFoundException
    {
        public DeliveryMethodsNotFound(int id) : base($"Delivery Method with id {id} was not found")
        {
            
        }
    }
}
