using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public  record DeliveryMethodRequestDTO
    {
        public int Id { get; init; }
        public string? Shortname { get; init; }
        public string Description { get; init; }
        public string DeliveryTime { get; init; }
        public decimal Cost { get; init; }
    }
}
