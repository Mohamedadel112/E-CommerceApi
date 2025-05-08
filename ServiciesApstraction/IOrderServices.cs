using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciesApstraction
{
    public interface IOrderServices
    {
        Task<OrderResultDTO> GetOrderByIDAsync(Guid Id);
        Task<IEnumerable<OrderResultDTO>> GetAllOrderByEmailAsync(string UserEmail);
        Task<OrderResultDTO> CreateOrderAsync(OrderRequestDTO request, string UserEmail);
        Task<IEnumerable<DeliveryMethodRequestDTO>> GetDeliveryAsync();
    }
}
