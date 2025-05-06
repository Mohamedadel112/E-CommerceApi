﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public record BasketDTO
    {

        public string Id { get; init; }
        public IEnumerable<BasketItemDTO> Items { get; init; }
        public string? PaymentIntentId { get; init; }
        public string? ClientSecret { get;init; }
        public decimal? ShippingPrice { get; init; }
        public int? DeliveryMethodId { get; init; }
    }
}
