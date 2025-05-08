using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciesApstraction
{
    public interface IPaymentService
    {
        Task<BasketDTO> CreateOrUpdatePaymentIntentAsync(string basketId);
        Task UpdatePaymentStatus(string request, string StripeHeaders);
    }
}
