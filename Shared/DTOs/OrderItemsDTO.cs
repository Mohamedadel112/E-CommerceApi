using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public record OrderItemsDTO
    {
        public int ProductId { get; init; }
        public string ProductName { get; init; }
        public string ProductPicture { get; init; }
        public int Quantity { get; init; }
        public decimal Price { get; init; }
    }
}
