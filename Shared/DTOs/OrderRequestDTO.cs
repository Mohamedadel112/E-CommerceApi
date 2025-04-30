using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public record OrderRequestDTO
    {
        public string BasketId { get; init; }
        public AddressDTO ShippingAddress { get; init; }
        public int DeliveryMethodId { get; init; }
    }
}
